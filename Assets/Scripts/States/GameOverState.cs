using CorruptedLandTales;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CorruptedLandTales
{
    public class GameOverState : GameState
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
        }
        public void MenuExit()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
