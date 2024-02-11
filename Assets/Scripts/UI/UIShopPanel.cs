using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CorruptedLandTales
{
    public class UIShopPanel : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private UIShopItem[] stats;
        
        [Header("Buttons")]
        [SerializeField] private UIBuyBtn m_buyBtn;
        [SerializeField] private UIRefreshBtn m_refreshBtn;

        [Header("Active Type")] 
        [SerializeField] private TMP_Text m_cost;
        [SerializeField] private TMP_Text m_type;
        
        private List<StatSO> m_playerStats;
        private StatSO activeStat;
        private string activeType;
        private int activeCost;
        
        public event System.Action<StatSO> onTryBuyItem;
        public event System.Action onRefresh; 
        
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
                    case "health":
                        stats[0].SetUpShopItem(stat);
                        stats[0].onClick += OnItemClick;
                        break;
                    case "speed":
                        stats[1].SetUpShopItem(stat);
                        stats[1].onClick += OnItemClick;
                        break;
                    case "manapool":
                        stats[2].SetUpShopItem(stat);
                        stats[2].onClick += OnItemClick;
                        break;
                    case "manaregen":
                        stats[3].SetUpShopItem(stat);
                        stats[3].onClick += OnItemClick;
                        break;
                }
            }
        }
        
        private void OnEnable()
        {
            ClearText();
        }

        private void OnDisable()
        {
            foreach (var stat in stats) 
            {
                stat.onClick -= OnItemClick;
            }
            m_buyBtn.onClickBuyButton -= OnBuyClick;
            m_refreshBtn.onClickRefreshButton -= OnRefreshClick;
            ClearText();
        }
        
        private void OnItemClick(StatSO stat)
        {
            activeStat = stat;
            activeType = stat.statName;
            activeCost = stat.cost;
            SetCostTypeAndLevel();
        }

        private void SetCostTypeAndLevel()
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

        private void ClearText()
        {
            m_cost.text = "";
            m_type.text = "";
        }
        public void RefreshStatsLevels()
        {
            foreach(var stat in stats)
            {
                stat.RefreshStatsLevelImagin();
            }
        }
    }
}
