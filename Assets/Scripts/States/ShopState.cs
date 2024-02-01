using System;
using UnityEngine;

namespace CorruptedLandTales
{
    public class ShopState : GameState
    {
        [SerializeField] private MainMenuState m_mainMenu;
        [SerializeField] private UIShopPanel m_shopPanel;
        private PlayerSettings m_player;
       
        
        protected override void OnEnable()
        {
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }
        
        protected override void OnEnter()
        {
            m_shopPanel.SetPlayerStatsAndShopItems(m_player.playerStats);
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
    }
}
