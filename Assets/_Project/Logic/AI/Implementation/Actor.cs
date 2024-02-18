using System.Collections.Generic;
using System.Linq;
using System.Text;
using _Project.AI.Core;
using _Project.AI.Extensions;
using UnityEngine;

namespace _Project.AI.Implementation
{
    public partial class Actor : IActor
    {
        private Queue<IAction> _behavior = new();
        
        private readonly List<IAction> _actions;
        private readonly List<IPassiveAction> _passiveActions;
        private readonly List<INeed> _needs;
        private readonly IWorldContext _world;
        private readonly IActorContext _context;

        public Actor(
            List<IAction> actions, 
            List<IPassiveAction> passiveActions, 
            List<INeed> needs, 
            IWorldContext world,
            IActorContext actorContext)
        {
            _actions = actions;
            _passiveActions = passiveActions;
            _needs = needs;
            _world = world;
            _context = actorContext;
        }

        public void Act(float delta)
        {
            _passiveActions.ForEach(x =>
            {
                if (x.CanApply(_context, _world))
                    x.Apply(_context, _world, delta);
            });

            if (_behavior is { Count: > 0 })
                return;
            
            if (_behavior == null || _behavior.Count == 0)
                _behavior = CreateBehavior();

            if (_behavior is { Count: > 0 })
            {
                LogBehavior();
                RunCurrentAction();
            }
        }

        private void RunCurrentAction()
        {
            IAction action = _behavior.Peek();
            action.StartApply(_context, _world);
            action.OnComplete += RunNextAction;
            action.Apply(_context, _world);
        }

        private void RunNextAction()
        {
            IAction action = _behavior.Peek();
            action.ApplyResult(_context, _world);
            action.OnComplete -= RunNextAction;
            _behavior.Dequeue();
            
            if (_behavior.Count > 0)
                RunCurrentAction();
        }

        private Queue<IAction> CreateBehavior()
        {
            INeed biggestNeed = _needs
                .OrderByDescending(x => x.Amount(_context, _world))
                .First();

            List<PossibleBehavior> possibleBehaviors = new()
            {
                new(biggestNeed, _context, _world),
            };

            int iterationsCount = 0;
            while (possibleBehaviors.All(x => !x.CanAccomplishNeed && x.Actions.Count <= _actions.Count)
                   && iterationsCount <= _actions.Count)
            {
                foreach (PossibleBehavior behavior in possibleBehaviors.ToArray())
                {
                    possibleBehaviors.Remove(behavior);

                    foreach (IAction action in _actions)
                    {
                        if (action.CanApply(behavior.Context, behavior.World))
                        {
                            IActorContext context = behavior.Context.Copy();
                            IWorldContext world = behavior.World.Copy();
                            
                            action.StartApply(context, world);
                            
                            float applyTime = action.GetApplyTime(context, world);
                            
                            _passiveActions.ForEach(x =>
                            {
                                if (x.CanApply(context, world))
                                    x.Apply(context, world, applyTime);
                            });
                            
                            action.ApplyResult(context, world);
                            
                            Queue<IAction> actionsQueue = new();
                            behavior.Actions.ForEach(x => actionsQueue.Enqueue(x));
                            actionsQueue.Enqueue(action);
                            possibleBehaviors.Add(new(biggestNeed, context, world, actionsQueue));
                        }
                    }

                }
                
                iterationsCount++;
            }

            PossibleBehavior possibleBehavior = possibleBehaviors
                .Find(x => x.CanAccomplishNeed);

            if (possibleBehavior.HasActions)
                return possibleBehavior.Actions;
            
            return null;
        }

        public IActor Copy() => 
            new Actor(_actions, _passiveActions, _needs, _world.Copy(), _context.Copy());

        private void LogBehavior() =>
            Debug.Log(new StringBuilder()
                .AppendLine("New behavior")
                .AppendLine(string.Empty)
                .AppendJoin("\n", _behavior.Select(x => $"{x.GetType().Name}"))
                .AppendLine(string.Empty)
                .AppendLine(_context.ToString())
                .AppendLine(string.Empty)
                .AppendLine(_world.ToString())
                .ToString());
    }
}