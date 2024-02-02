using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class UIShopPanel : MonoBehaviour
    {
        public event System.Action<StatSO> onTryBuyItem;
        public event System.Action onRefresh; 
        
        [SerializeField] private UIShopItem m_healthStat;
        [SerializeField] private UIShopItem m_damageStat;
        [SerializeField] private UIShopItem m_speedStat;
        [SerializeField] private UIShopItem m_attackSpeedStat;
        [SerializeField] private UIShopItem m_manaPoolStat;
        [SerializeField] private UIShopItem m_manaRegenStat;
        [SerializeField] private UIBuyBtn m_buyBtn;
        [SerializeField] private UIRefreshBtn m_refreshBtn;
        [SerializeField] private TMP_Text m_cost;
        [SerializeField] private TMP_Text m_type;
        private List<StatSO> m_playerStats;

        private StatSO activeStat;
        private string activeType;
        private int activeCost;
        
        //TODO переписать этот говнокод
        public void SetPlayerStatsAndShopItems(PlayerStatsDB playerStatsDB)
        {
            ClearText();
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

        private void RefreshCost(StatSO stat)
        {
            m_manaPoolStat.SetUpShopItem(stat);
        }

        private void OnItemClick(StatSO stat)
        {
            activeStat = stat;
            activeType = stat.statName;
            activeCost = stat.cost;
            SetCostAndType();
        }

        private void SetCostAndType()
        {
            m_cost.text = activeCost.ToString();
            m_type.text = activeType;
        }
        
        private void OnBuyClick()
        {
            onTryBuyItem?.Invoke(activeStat);
            RefreshCost(activeStat);
            OnItemClick(activeStat);
        }

        private void OnRefreshClick()
        {
            onRefresh?.Invoke();
        }

        private void OnDisable() // переписать этот говнокод
        {
            m_healthStat.onClick -= OnItemClick;
            m_damageStat.onClick -= OnItemClick;
            m_speedStat.onClick -= OnItemClick;
            m_attackSpeedStat.onClick -= OnItemClick;
            m_manaPoolStat.onClick -= OnItemClick;
            m_manaRegenStat.onClick -= OnItemClick;
            m_buyBtn.onClickBuyButton -= OnBuyClick;
            m_refreshBtn.onClickRefreshButton -= OnRefreshClick;
            ClearText();
        }

        private void ClearText()
        {
            m_cost.text = "";
            m_type.text = "";
        }
    }
}
