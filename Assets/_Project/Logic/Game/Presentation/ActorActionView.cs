using UnityEngine;
using UnityEngine.UI;

namespace _Project.Game.Presentation
{
    internal class ActorActionView : MonoBehaviour
    {
        [SerializeField] private Text _title;

        public void Setup(string actionName) => 
            _title.text = actionName;
    }
}