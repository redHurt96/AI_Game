using System.Collections.Generic;
using System.Linq;
using System.Text;
using _Project.AI.Core;
using _Project.AI.Extensions;
using UnityEngine;
using static System.String;
using static UnityEngine.Mathf;

namespace _Project.AI.Implementation
{
    public partial class Actor<TContext> : IActor where TContext : IActorContext
    {
        private Queue<IAction<TContext>> _behavior = new();
        
        private readonly List<IAction<TContext>> _actions;
        private readonly List<IPassiveAction<TContext>> _passiveActions;
        private readonly List<INeed<TContext>> _needs;
        private readonly TContext _context;

        public Actor(
            List<IAction<TContext>> actions, 
            List<IPassiveAction<TContext>> passiveActions, 
            List<INeed<TContext>> needs,
            TContext actorContext)
        {
            _actions = actions;
            _passiveActions = passiveActions;
            _needs = needs;
            _context = actorContext;
        }

        public void Act(float delta)
        {
            _passiveActions.ForEach(x =>
            {
                if (x.CanApply(_context))
                    x.Apply(_context, delta);
            });

            if (_behavior is { Count: > 0 })
            {
                RunCurrentAction();                
                return;
            }
            
            if (_behavior == null || _behavior.Count == 0)
                _behavior = CreateBehavior();

            if (_behavior is { Count: > 0 })
            {
                LogBehavior();
            }
        }

        private void RunCurrentAction()
        {
            IAction<TContext> action = _behavior.Peek();

            if (action is ILongAction<TContext> longAction && !longAction.IsComplete(_context))
            {
                longAction.Execute(_context);
            }
            else
            {
                action.ApplyResult(_context);
                _behavior.Dequeue();
            }
        }

        private Queue<IAction<TContext>> CreateBehavior()
        {
            INeed<TContext> biggestNeed = GetNeed();

            if (biggestNeed == null)
                return null;
            
            List<PossibleBehavior> possibleBehaviors = new()
            {
                new(biggestNeed, (TContext)_context.Copy()),
            };

            int iterationsCount = 0;
            while (possibleBehaviors.All(x => !x.CanAccomplishNeed && x.Actions.Count <= _actions.Count)
                   && iterationsCount <= _actions.Count)
            {
                foreach (PossibleBehavior behavior in possibleBehaviors.ToArray())
                {
                    possibleBehaviors.Remove(behavior);

                    foreach (IAction<TContext> action in _actions)
                    {
                        if (action.CanApply(behavior.Context))
                        {
                            TContext context = (TContext)behavior.Context.Copy();
                            action.ApplyResult(context);

                            Queue<IAction<TContext>> actionsQueue = new();
                            behavior.Actions.ForEach(x => actionsQueue.Enqueue(x));
                            actionsQueue.Enqueue(action);
                            possibleBehaviors.Add(new(biggestNeed, context, actionsQueue));
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

        private INeed<TContext> GetNeed()
        {
            if (_needs.All(x => Approximately(x.Amount(_context), 0f)))
                return null;

            return _needs
                .OrderByDescending(x => x.Amount(_context))
                .FirstOrDefault();
        }

        public IActor Copy() => 
            new Actor<TContext>(_actions, _passiveActions, _needs, (TContext)_context.Copy());

        private void LogBehavior() =>
            Debug.Log(new StringBuilder()
                .AppendLine("New behavior")
                .AppendJoin("\n", _behavior.Select(x => $"{x.GetType().Name}"))
                .AppendLine(Empty)
                .AppendLine(_context.ToString())
                .AppendLine(Empty)
                .ToString());
    }
}