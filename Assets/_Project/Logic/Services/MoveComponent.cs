using System;
using _Project.Game.Domain;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Services
{
    public class MoveComponent : MonoBehaviour, IMoveComponent
    {
        public IObservable<Vector3> PositionChanged { get; private set; }
        public Vector3 Position => transform.position;
        public Vector3 Target => _navMeshAgent.destination;

        [SerializeField] private NavMeshAgent _navMeshAgent;

        private void Awake() =>
            PositionChanged = transform
                .ObserveEveryValueChanged(x => x.position);

        public void Move(Vector3 to) => 
            _navMeshAgent.SetDestination(to);
    }
}