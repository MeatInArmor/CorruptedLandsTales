using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CorruptedLandTales
{
    public class UIShopPanel : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private UIShopItem m_healthStat;
        [SerializeField] private UIShopItem m_damageStat;
        [SerializeField] private UIShopItem m_speedStat;
        [SerializeField] private UIShopItem m_attackSpeedStat;
        [SerializeField] private UIShopItem m_manaPoolStat;
        [SerializeField] private UIShopItem m_manaRegenStat;
        
        [Header("Buttons")]
        [SerializeField] private UIBuyBtn m_buyBtn;
        [SerializeField] private UIRefreshBtn m_refreshBtn;

        [Header("Active Type")] 
        [SerializeField] private UILevelPanel m_levelPanel;
        [SerializeField] private TMP_Text m_cost;
        [SerializeField] private TMP_Text m_type;
        
        private List<StatSO> m_playerStats;
        private StatSO activeStat;
        private string activeType;
        private int activeCost;
        private int activeLevel;
        
        public event System.Action<StatSO> onTryBuyItem;
        public event System.Action onRefresh; 
        
        public void SetPlayerStatsAndShopItems(PlayerStatsDB playerStatsDB)
        {
            Clear();
            m_buyBtn.onClickBuyButton += OnBuyClick;
            m_playerStats = playerStatsDB.stats;
            m_refreshBtn.onClickRefreshButton += OnRefreshClick;
            foreach (var stat in m_playerStats)
            {
                if (stat.statName == "health")
                {
                    m_healthStat.SetUpShopItem(stat);
                    m_healthStat.onClick += OnItemClick;
                }
                if (stat.statName == "attack")
                {
                    m_damageStat.SetUpShopItem(stat);
                    m_damageStat.onClick += OnItemClick;
                }
                if (stat.statName == "attackspeed")
                {
                    m_attackSpeedStat.SetUpShopItem(stat);
                    m_attackSpeedStat.onClick += OnItemClick;
                }
                if (stat.statName == "manapool")
                {
                    m_manaPoolStat.SetUpShopItem(stat);
                    m_manaPoolStat.onClick += OnItemClick;
                }
                if (stat.statName == "manaregen")
                {
                    m_manaRegenStat.SetUpShopItem(stat);
                    m_manaRegenStat.onClick += OnItemClick;
                }
                if (stat.statName == "speed")
                {
                    m_speedStat.SetUpShopItem(stat);
                    m_speedStat.onClick += OnItemClick;
                }
            }
        }
        
        private void OnEnable()
        {
            Clear();
        }

        private void OnDisable()
        {
            m_healthStat.onClick -= OnItemClick;
            m_damageStat.onClick -= OnItemClick;
            m_speedStat.onClick -= OnItemClick;
            m_attackSpeedStat.onClick -= OnItemClick;
            m_manaPoolStat.onClick -= OnItemClick;
            m_manaRegenStat.onClick -= OnItemClick;
            m_buyBtn.onClickBuyButton -= OnBuyClick;
            m_refreshBtn.onClickRefreshButton -= OnRefreshClick;
            Clear();
        }
        
        private void OnItemClick(StatSO stat)
        {
            activeStat = stat;
            activeType = stat.statName;
            activeCost = stat.cost;
            activeLevel = stat.level;
            SetCostTypeAndLevel();
        }

        private void SetCostTypeAndLevel()
        {
            m_cost.text = activeCost.ToString();
            m_type.text = activeType;
            m_levelPanel.RefreshLevels();
            m_levelPanel.SetUpLevels(activeLevel);
        }
        
        private void OnBuyClick()
        {
            onTryBuyItem?.Invoke(activeStat);
            OnItemClick(activeStat);
        }

        private void OnRefreshClick()
        {
            onRefresh?.Invoke();
        }

        private void Clear()
        {
            m_cost.text = "";
            m_type.text = "";
            m_levelPanel.RefreshLevels();
        }
    }
}
