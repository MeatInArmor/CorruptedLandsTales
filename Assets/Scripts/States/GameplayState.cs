using CorruptedLandTales;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class GameplayState : GameState
    {
        public GameOverState gameOverState;
        public GameWinState gameWinState;
        public PauseState pauseState;
        public MapState mapState;
        
        protected override void OnEnable()
        {
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }
        public void GameOver()
        {
            Exit();
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
