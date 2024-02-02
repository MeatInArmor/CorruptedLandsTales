using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class MainMenuState : GameState
    {
        public SettingsState settingsState;
        [SerializeField] private ShopState m_shopState;

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
        public void GoToSettings()
        {
            settingsState.Enter();
            Exit();
        }

        public void GoToShop()
        {
            m_shopState.Enter();
            Exit();
        }
    }
}
