using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CorruptedLandTales
{
    public class GameWinState : GameState
    {
        protected override void OnEnable()
        {
            base.OnEnable();
        }   
        protected override void OnDisable()
        {
            base.OnDisable();
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