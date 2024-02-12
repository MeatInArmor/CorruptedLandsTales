using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "StatsIncreaseSO", menuName = "CorruptedLandTales/StatsIncreaseSO")]
    public class StatsIncreaseSO : ScriptableObject
    {
        public MoveDataIncrease moveData;
        public HealthDataIncrease healthData;
        public AttackIncrease atkData;
        [FormerlySerializedAs("manaDataIncrease")] public ManaDataIncrease manaData;
    }

    [System.Serializable]
    public class HealthDataIncrease
    {
        public float health = 100;
    }
    
    [System.Serializable]
    public class AttackIncrease
    {
        public float dmg = 30;
    }
    
    [System.Serializable]
    public class MoveDataIncrease
    {
        public float speed = 5f;
    }
    
    [System.Serializable]
    public class ManaDataIncrease
    {
        public float mana = 0;
        public float manaRegen = 0;
    }
}
