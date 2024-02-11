using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace CorruptedLandTales
{
    public class GameplayState : GameState
    {
        public GameOverState gameOverState;
        public GameWinState gameWinState;
        public PauseState pauseState;
        public MapState mapState;
        public HealthComponent m_healthComponent;

        protected override void OnEnable()
        {
            m_healthComponent.onDie += GameOver;
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            m_healthComponent.onDie -= GameOver;
            base.OnDisable();
        }
        public void GameOver()
        {
            Exit();
            mapState.Exit();
            gameOverState.Enter();
        }
        //private void OnGameWin()
        //{
        //    Exit();
        //    gameWinState.Enter();
        //}
        public void Pause()
        {   
            Exit();
            mapState.Exit();
            pauseState.Enter();
        }

        
    }
}
