using System.Linq;
using _Project.AI.Implementation;
using UnityEngine;

namespace _Project.Game.Presentation
{
    public class ActorPlanView : MonoBehaviour
    {
        [SerializeField] private ActorActionView _actionViewPrefab;
        
        private IActorView _actorView;
        private int _actionsCount;

        public void Setup(IActorView actorView) => 
            _actorView = actorView;

        private void Update()
        {
            if (_actorView.Behavior == null)
                return;
            
            int count = _actorView.Behavior.Count();

            if (_actionsCount != count)
                Redraw();

            _actionsCount = count;
        }

        private void Redraw()
        {
            for (int i = 0; i < transform.childCount; i++) 
                Destroy(transform.GetChild(i).gameObject);

            foreach (string actionName in _actorView.Behavior)
                Instantiate(_actionViewPrefab, transform)
                    .Setup(actionName);
        }
    }
}
