using UnityEngine;

namespace _Project.Game.Domain
{
    [CreateAssetMenu(menuName = "Create CharacterConfig", fileName = "CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [field:SerializeField] public float EatSpeed {get; private set; } = .5f;
        [field:SerializeField] public float SleepSpeed {get; private set; } = .5f;
        [field:SerializeField] public float SpendEnergySpeed {get; private set; } = .05f;
        [field:SerializeField] public float SpendFoodEnergySpeed {get; private set; } = .05f;
        [field:SerializeField] public float MoveStoppingDistance {get; private set; } = .5f;
    }
}