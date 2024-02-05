using System;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class ShopState : GameState
    {
        [SerializeField] private MainMenuState m_mainMenu;
        [SerializeField] private UIShopPanel m_shopPanel;
        [SerializeField] private PlayerStatsDB m_playerStatsSO;
        private PlayerSettings m_player;
        //private PlayerStatsDB m_playerStatsSO;
        private List<StatSO> m_playerStats;
       
        
        protected override void OnEnable()
        {
            base.OnEnable();
            m_shopPanel.onTryBuyItem += OnTryBuyItem;
            m_shopPanel.onRefresh += RefreshStats;

        }
        protected override void OnDisable()
        {
            base.OnDisable();
            m_shopPanel.onTryBuyItem -= OnTryBuyItem;
            m_shopPanel.onRefresh -= RefreshStats;
        }
        
        protected override void OnEnter()
        {
            m_shopPanel.SetPlayerStatsAndShopItems(m_playerStatsSO);
            m_shopPanel.RefreshStatsLevels();
        }

        private void Awake()
        {
            m_player = GameInstance.instance.playerSettings;
            m_playerStatsSO = Resources.Load<PlayerStatsDB>("PlayerStatsDB");
            m_playerStats = m_playerStatsSO.stats;
        }

        public void GoToMainMenu()
        {
            m_mainMenu.Enter();
            Exit();
        }

        private void RefreshStats()
        {
            foreach (var stat in m_playerStats)
            {
                stat.RefreshStats();
            }
            
        }

        private void OnTryBuyItem(StatSO stat)
        {
            Debug.Log($"Try buy! - {stat.statName}");
            
            var itemData = m_playerStats.Find(x=> x.statName == stat.statName);
            if (itemData != null)
            {
                if (m_player.money > itemData.cost)
                {
                    itemData.IncreaseStatLevel();
                    m_player.money -= itemData.cost;
                    itemData.IncreaseCost();
                    Debug.Log($"{itemData.statName} BUY!!!");
                }
            }
        }
    }
}
