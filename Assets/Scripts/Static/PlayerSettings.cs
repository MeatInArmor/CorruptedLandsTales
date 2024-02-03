using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class PlayerSettings
    {
        public Settings settings {  get; private set; } = new Settings();

        private int m_money = 1000;
        public event System.Action<int> changeMoney;

        public int money
        {
            set
            {
                if (m_money != value)
                {
                    m_money = value;
                    changeMoney?.Invoke(m_money);
                }
            }
            get => m_money;
        }
        
        public void Save()
        {
            var json = JsonUtility.ToJson(settings);
            PlayerPrefs.SetString("playerSettings.settings", json);
            
            json = JsonUtility.ToJson(new PlayerData()
            {
                money = m_money,
            });
            
            PlayerPrefs.SetString("player.data", json);
        }
        
        public void Load() 
        {
            var json = PlayerPrefs.GetString("playerSettings.settings");
            if(!string.IsNullOrEmpty(json))
            {
                settings = JsonUtility.FromJson<Settings>(json);
            }
            
            json = PlayerPrefs.GetString("player.data");
            
            if (!string.IsNullOrEmpty(json))
            {
                var playerData = JsonUtility.FromJson<PlayerData>(json);
                m_money = playerData.money;
            }
        }

        [System.Serializable]
        public class Settings
        {
            public float musicVolume = 50;
            public float fxVolume = 50;
            public int quality = 5;
        }
        
        [System.Serializable]
        private class PlayerData
        {
            public int money;
        }
    }
}
