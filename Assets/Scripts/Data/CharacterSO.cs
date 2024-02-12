using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "CharacterSO", menuName = "CorruptedLandTales/CharacterSO")]
    public class CharacterSO : ScriptableObject
    {
        public MoveData moveData;
        public HealthData healthData;
        public WeaponSO weapon;
        public ManaData manaData;
        public AttackData atkData;

        [SerializeField] private StatsIncreaseSO m_stats;
        public StatsIncreaseSO stats => m_stats; 
        
        public void IncreaseStats()
        {
            if (m_stats!=null)
            {
                moveData.speed += m_stats.moveData.speed;
                healthData.maxHealth += m_stats.healthData.health;
                healthData.health += m_stats.healthData.health;
                if (weapon!=null)
                {
                    weapon.IncreaseDamage(m_stats.atkData.dmg);
                }
                manaData.manaPool += m_stats.manaData.mana;
                if (m_stats.manaData.manaRegen != 0)
                {
                    manaData.manaRegen += m_stats.manaData.manaRegen;
                }
            }
        }

        public void RefreshStats(CharacterSO stats)
        {
            moveData.speed = stats.moveData.speed;
            healthData.maxHealth = stats.healthData.health;
            healthData.health = stats.healthData.health;
            if (weapon!=null)
            {
                weapon.SetDamage(stats.atkData.damage);
            }
            manaData.manaPool = stats.manaData.manaPool;
            manaData.manaRegen = stats.manaData.manaRegen;
        }
    }

    [System.Serializable]
    public class HealthData
    {
        public float health = 100;
        public float maxHealth = 100;
    }
    
    [System.Serializable]
    public class AttackData
    {
        public float damage = 30;
    }

    [System.Serializable]
    public class MoveData
    {
        public float speed = 5f;
        public float sprintSpeed = 10f;
    }

    [System.Serializable]
    public class ManaData
    {
        public float manaPool = 50f;
        public float initMana = 0f;
        public float manaRegen = 0f;
    }
}
