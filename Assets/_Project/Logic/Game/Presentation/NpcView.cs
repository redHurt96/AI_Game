using _Project.Game.Domain;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Presentation
{
    public class NpcView : MonoBehaviour
    {
        [SerializeField] private Image _foodBar;
        [SerializeField] private Image _energyBar;
        
        private NpcContext _npcContext;

        public void Setup(NpcContext npcContext)
        {
            _npcContext = npcContext;
            _npcContext.Position.Subscribe(Move).AddTo(this);
            _npcContext.Energy.Subscribe(UpdateEnergy).AddTo(this);
            _npcContext.FoodEnergy.Subscribe(UpdateFood).AddTo(this);
        }

        private void Move(Vector3 to) => 
            transform.position = to;
        
        private void UpdateEnergy(float to) => _energyBar.fillAmount = to;
        private void UpdateFood(float to) => _foodBar.fillAmount = to;
    }
}
