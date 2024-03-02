using _Project.Game.Domain;
using UnityEngine;

namespace _Project.Presentation
{
    public class FoodView : MonoBehaviour
    {
        private Food _food;

        public void Setup(Food food)
        {
            _food = food;
            transform.position = food.Position;
            _food.Destroyed += () => Destroy(gameObject);
        }
    }
}