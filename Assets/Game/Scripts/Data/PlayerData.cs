using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Data/Player")]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField] public float MaxSpeed { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        [field: SerializeField] public float Deceleration { get; private set; }
    }
}
