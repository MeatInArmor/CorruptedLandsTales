using System;
using ShadowChimera;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CorruptedLandTales
{
    public class GameOverState : GameState
    {
        [SerializeField] private RewardCounter m_rewardCounter;
        [SerializeField] private UIGameOverPanel m_gameOverPanel;
        private PlayerSettings m_player;
        
        protected override void OnEnable()
        {
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }

        private void Awake()
        {
            m_player = GameInstance.instance.playerSettings;
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            Debug.Log($"{m_player.money}");
            m_player.money += m_rewardCounter.CountReward();
            Debug.Log($"{m_player.money} {m_rewardCounter.CountReward()}");
            m_gameOverPanel.SetPlayerReward(m_rewardCounter.CountReward());
        }

        public void Restart()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            NumbersCounts.kills = 0;
            NumbersCounts.levelsCleared = 0;

        }
        public void MenuExit()
        {
            SceneManager.LoadScene("MainMenu");
            NumbersCounts.kills = 0;
            NumbersCounts.levelsCleared = 0;
        }
    }
}
