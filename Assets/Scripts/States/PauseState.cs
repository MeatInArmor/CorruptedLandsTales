using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CorruptedLandTales
{
    public class PauseState : GameState
    {
        public GameplayState gameplayState;
        public MapState mapState;

        protected override void OnEnable()
        {
            base.OnEnable();
            Time.timeScale = 0;
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            Time.timeScale = 1;

        }
        public void Restart()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        public void Resume()
        {
            Exit();
            gameplayState.Enter();
            mapState.Enter();

        }
        public void MenuExit()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
