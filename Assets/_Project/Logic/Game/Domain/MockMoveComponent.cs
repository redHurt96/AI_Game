using System;
using UnityEngine;

namespace _Project.Game.Domain
{
    internal class MockMoveComponent : IMoveComponent
    {
        public IObservable<Vector3> PositionChanged { get; }
        public Vector3 Position { get; private set; }
        public Vector3 Target { get; private set; }

        public MockMoveComponent(IMoveComponent origin) => 
            Position = origin.Position;

        public void Move(Vector3 to)
        {
            Target = to;
            Position = to;
        }
    }
}