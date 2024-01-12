using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CorruptedLandTales
{
    public class MainMenuState : GameState
    {

        protected override void OnEnable()
        {
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }
        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();

#endif
        }
        public void LoadLevel()
        {
            SceneManager.LoadScene("GameLocation");
        }
    }
}
