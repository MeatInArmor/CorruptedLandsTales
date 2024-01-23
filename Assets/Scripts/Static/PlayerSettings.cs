using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class PlayerSettings
    {
        public Settings settings {  get; private set; } = new Settings();

        public void Save()
        {
            var json = JsonUtility.ToJson(settings);
            PlayerPrefs.SetString("playerSettings.settings", json);
        }
        public void Load() 
        {
            var json = PlayerPrefs.GetString("playerSettings.settings");
            if(string.IsNullOrEmpty(json))
            {
                return;
            }
            settings = JsonUtility.FromJson<Settings>(json);

        }

        [System.Serializable]
        public class Settings
        {
            public float musicVolume = 50;
            public float fxVolume = 50;
            public int quality = 5;
        }
    }
}
