using System;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class ShopState : GameState
    {
        [SerializeField] private MainMenuState m_mainMenu;
        [SerializeField] private UIShopPanel m_shopPanel;
        private PlayerSettings m_player;
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
            m_shopPanel.SetPlayerStatsAndShopItems(m_player.playerStats);
            m_playerStats = new List<StatSO>();
            m_playerStats = m_player.playerStats.stats;
        }

        private void Awake()
        {
            m_player = GameInstance.instance.playerSettings;
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

        private void OnTryBuyItem(string item)
        {
            Debug.Log($"Try buy! - {item}");
            
            var itemData = m_playerStats.Find(x=> x.statName == item);
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
