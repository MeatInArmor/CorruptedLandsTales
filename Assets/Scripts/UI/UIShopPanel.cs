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

        [SerializeField] public UIShopItem[] stats;
        //[SerializeField] private UIShopItem m_healthStat;
        //[SerializeField] private UIShopItem m_damageStat;
        //[SerializeField] private UIShopItem m_speedStat;
        //[SerializeField] private UIShopItem m_attackSpeedStat;
        //[SerializeField] private UIShopItem m_manaPoolStat;
        //[SerializeField] private UIShopItem m_manaRegenStat;
        [SerializeField] private UIBuyBtn m_buyBtn;
        [SerializeField] private UIRefreshBtn m_refreshBtn;
        [SerializeField] private TMP_Text m_cost;
        [SerializeField] private TMP_Text m_type;
        private List<StatSO> m_playerStats;

        private StatSO activeStat;
        private string activeType;
        private int activeCost;
        
        public void SetPlayerStatsAndShopItems(PlayerStatsDB playerStatsDB)
        {
            ClearText();
            m_buyBtn.onClickBuyButton += OnBuyClick;
            m_playerStats = playerStatsDB.stats;
            m_refreshBtn.onClickRefreshButton += OnRefreshClick;
            foreach (var stat in m_playerStats)
            {
                switch (stat.statName)
                {
                    case "здоровье":
                        stats[0].SetUpShopItem(stat);
                        stats[0].onClick += OnItemClick;
                        break;

                    case "сила атаки":
                        stats[1].SetUpShopItem(stat);
                        stats[1].onClick += OnItemClick;
                        break;
                    case "скорость движения":
                        stats[2].SetUpShopItem(stat);
                        stats[2].onClick += OnItemClick;
                        break;
                    case "скорость атаки":
                        stats[3].SetUpShopItem(stat);
                        stats[3].onClick += OnItemClick;
                        break;

                    case "сила духа":
                        stats[4].SetUpShopItem(stat);
                        stats[4].onClick += OnItemClick;
                        break;
                    case "укрепление духа":
                        stats[5].SetUpShopItem(stat);
                        stats[5].onClick += OnItemClick;
                        break;
                }
            }
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
            OnItemClick(activeStat);
            RefreshStatsLevels();
        }

        private void OnRefreshClick()
        {
            onRefresh?.Invoke();
            RefreshStatsLevels();
        }

        private void OnDisable()
        {
            foreach(var stat in stats)
            {
                stat.onClick -= OnItemClick;
            }
            //m_healthStat.onClick -= OnItemClick;
            //m_damageStat.onClick -= OnItemClick;
            //m_speedStat.onClick -= OnItemClick;
            //m_attackSpeedStat.onClick -= OnItemClick;
            //m_manaPoolStat.onClick -= OnItemClick;
            //m_manaRegenStat.onClick -= OnItemClick;
            m_buyBtn.onClickBuyButton -= OnBuyClick;
            m_refreshBtn.onClickRefreshButton -= OnRefreshClick;
            ClearText();
        }

        private void ClearText()
        {
            m_cost.text = "";
            m_type.text = "";
        }
        public void RefreshStatsLevels()
        {
            foreach (var stat in stats)
            {
                stat.RefreshStatsLevelImagin();
            }
        }
    }
}
