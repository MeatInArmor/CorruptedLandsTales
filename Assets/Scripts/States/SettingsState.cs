using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class SettingsState : GameState
    {
        public MainMenuState mainMenuState;
        [SerializeField] SettingsPanel m_settingsPanel;

        private PlayerSettings.Settings settings => GameInstance.instance.playerSettings.settings;

        protected override void OnEnable()
        {
            base.OnEnable();
            Debug.Log(GameInstance.instance);

            if (GameInstance.instance == null)
            {
                return;
            }
            m_settingsPanel.SetMusic(settings.musicVolume);
            m_settingsPanel.SetFx(settings.fxVolume);
            m_settingsPanel.SetQuallity(settings.quality);

            m_settingsPanel.onMusicVolumeChanged += OnMusicVolumeChanged;
            m_settingsPanel.onFxVolumeChanged += OnFxVolumeChanged;
            m_settingsPanel.onQuallityChanged += OnQuallityChanged;

        }
        protected override void OnDisable()
        {

            base.OnDisable();
            m_settingsPanel.onMusicVolumeChanged -= OnMusicVolumeChanged;
            m_settingsPanel.onFxVolumeChanged -= OnFxVolumeChanged;
            m_settingsPanel.onQuallityChanged -= OnQuallityChanged;

            GameInstance.instance.ApplySettings();
        }
        public void CloseSettings()
        {
            mainMenuState.Enter();
            Exit();
        }
        private void OnMusicVolumeChanged(int value)
        {
            settings.musicVolume = value;
        }
        private void OnFxVolumeChanged(int value)
        {
            settings.fxVolume = value;
        }
        private void OnQuallityChanged(int index)
        {
            settings.quality = index;
        }
    }
}
