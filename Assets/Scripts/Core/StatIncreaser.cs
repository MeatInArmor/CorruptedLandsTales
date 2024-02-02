using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class StatIncreaser : MonoBehaviour
    {
        [SerializeField] private TimeController m_timeController;
        [Header("Boss")]
        [SerializeField] private BossSO m_bossData;
        [SerializeField] private BossSO m_bossPreset;
        [SerializeField] private ProjectileComponent m_bossProjectile;
        [Header("Melee")]
        [SerializeField] private CharacterSO m_meleeData;
        [SerializeField] private CharacterSO m_meleePreset;
        [Header("Range")]
        [SerializeField] private CharacterSO m_rangeData;
        [SerializeField] private CharacterSO m_rangePreset;
        [SerializeField] private ProjectileComponent m_rangeProjectile; //TODO костыль
        [Header("GameController")]
        [SerializeField] private GameController m_gameController;
        [Header("")]
        [SerializeField] private int m_newEnemyPerTime;

        [Header("Player")] 
        [SerializeField] private CharacterSO m_player;
        [SerializeField] private StatsIncreaseSO m_playerIncreaseStatsSo;
        
        private PlayerSettings m_playerSettings;
        private List<StatSO> m_playerStats;
        
        private void Awake()
        {
            m_playerSettings = GameInstance.instance.playerSettings;
            m_meleeData.RefreshStats(m_meleePreset);
            m_rangeData.RefreshStats(m_rangePreset);
            m_bossData.RefreshStats(m_bossPreset);
            m_rangeProjectile.RefreshDamage(m_rangePreset.atkData.damage);
            m_playerStats = new List<StatSO>();
            m_playerStats = m_playerSettings.playerStats.stats;
            foreach (var stat in m_playerStats)
            {
                var lvl = stat.level;
                if (stat.statName == "health")
                {
                    m_playerIncreaseStatsSo.healthData.health += stat.level * stat.valuePerLevel;
                }
                if (stat.statName == "attack")
                {
                    m_playerIncreaseStatsSo.atkData.dmg += stat.level * stat.valuePerLevel;
                }
                if (stat.statName == "attackspeed")
                {
                    Debug.Log("Try to increase attackspeed stat");
                }
                if (stat.statName == "manapool")
                {
                    m_playerIncreaseStatsSo.manaData.mana += stat.level * stat.valuePerLevel;
                }
                if (stat.statName == "manaregen")
                {
                    Debug.Log("Try to increase manaregen stat");
                }
                if (stat.statName == "speed")
                {
                    m_playerIncreaseStatsSo.moveData.speed += stat.level * stat.valuePerLevel;
                }
            }
            m_player.IncreaseStats();
        }

        private void Start()
        {
            m_gameController.onResetLevelcontroller += IncreaseStats;
        }
        
        
        private void OnDisable()
        {
            m_gameController.onResetLevelcontroller -= IncreaseStats;
        }
        
        private void IncreaseStats()
        {
            for (int i = 0; i < m_timeController.GetMobLevel(); i++) 
            {
                    m_meleeData.IncreaseStats();
                    m_rangeData.IncreaseStats();
                    m_bossData.IncreaseStats();
                    m_bossData.IncreaseAttacksDamage();
                    m_rangeProjectile.IncreaseDamage(m_rangeData.atkData.damage);
                    m_bossProjectile.IncreaseDamage(m_bossData.atkData.damage);
            }
            for (int i = 0; i < m_timeController.GetNewCount(); i++) 
            {
                m_gameController.activeLevelController.IncreaseEnemyCount(m_newEnemyPerTime);
            }
        }
    }
}
