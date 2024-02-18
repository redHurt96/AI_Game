using System.Collections.Generic;
using System.Linq;
using _Project.AI.Core;
using _Project.AI.Extensions;

namespace _Project.AI.Implementation
{
    internal partial class Actor : IActor
    {
        private Queue<IAction> _behavior = new();
        
        private readonly List<IAction> _actions;
        private readonly List<IPassiveAction> _passiveActions;
        private readonly List<INeed> _needs;
        private readonly IWorldContext _world;
        private readonly IActorContext _context;

        internal Actor(
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

            if (_behavior.Count == 0)
                _behavior = CreateBehavior();

            RunCurrentAction();
        }

        private void RunCurrentAction()
        {
            _behavior.Peek().Run(_context, _world);
            _behavior.Peek().OnComplete += RunNextAction;
        }

        private void RunNextAction()
        {
            _behavior.Peek().OnComplete -= RunNextAction;
            _behavior.Dequeue();
            
            RunCurrentAction();
        }

        private Queue<IAction> CreateBehavior()
        {
            INeed biggestNeed = _needs
                .OrderBy(x => x.Amount(_context, _world))
                .First();

            List<PossibleBehavior> possibleBehaviors = new()
            {
                new(biggestNeed, _context, _world),
            };

            while (possibleBehaviors.All(x => !x.CanAccomplishNeed))
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
                            float applyTime = action.ApplyInstant(context, world);
                            
                            _passiveActions.ForEach(x =>
                            {
                                if (x.CanApply(context, world))
                                    x.Apply(context, world, applyTime);
                            });
                            
                            Queue<IAction> actionsQueue = new();
                            behavior.Actions.ForEach(x => actionsQueue.Enqueue(x));
                            actionsQueue.Enqueue(action);

                            possibleBehaviors.Add(new(biggestNeed, context, world, actionsQueue));
                        }
                    }
                }
            }

            return possibleBehaviors
                .Find(x => x.CanAccomplishNeed)
                .Actions;
        }

        public IActor Copy() => 
            new Actor(_actions, _passiveActions, _needs, _world.Copy(), _context.Copy());
    }
}