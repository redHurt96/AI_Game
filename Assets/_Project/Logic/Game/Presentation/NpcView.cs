using _Project.AI.Implementation;
using _Project.Game.Domain;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Game.Presentation
{
    public class NpcView : MonoBehaviour
    {
        [SerializeField] private Image _foodBar;
        [SerializeField] private Image _energyBar;
        [SerializeField] private ActorPlanView _planView;
        
        private Character _character;

        public void Setup(Character character, Actor<Character> actor)
        {
            _character = character;
            _planView.Setup(actor);
            _character.MoveComponent.PositionChanged.Subscribe(Move).AddTo(this);
            _character.Energy.Subscribe(UpdateEnergy).AddTo(this);
            _character.FoodEnergy.Subscribe(UpdateFood).AddTo(this);
        }

        private void Move(Vector3 to) => 
            transform.position = to;
        
        private void UpdateEnergy(float to) => _energyBar.fillAmount = to;
        private void UpdateFood(float to) => _foodBar.fillAmount = to;
    }
}
