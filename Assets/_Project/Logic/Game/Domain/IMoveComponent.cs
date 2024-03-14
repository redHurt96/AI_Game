using System;
using UnityEngine;

namespace _Project.Game.Domain
{
    public interface IMoveComponent
    {
        IObservable<Vector3> PositionChanged { get; }
        Vector3 Position { get; }
        Vector3 Target { get; }

        void Move(Vector3 to);

        public sealed float DistanceTo(Vector3 target) => Vector3.Distance(Position, target);
    }
}