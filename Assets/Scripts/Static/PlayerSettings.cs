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
            
        private PlayerStatsDB m_playerStats;
        
        public PlayerStatsDB playerStats
        {
            get => m_playerStats;
        }
        
        public void Save()
        {
            var json = JsonUtility.ToJson(settings);
            PlayerPrefs.SetString("playerSettings.settings", json);
            
            json = JsonUtility.ToJson(new PlayerData()
            {
                money = m_money,
                //playerStats = m_playerStats,
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
            //m_playerStats = new PlayerStatsDB();
            m_playerStats = Resources.Load<PlayerStatsDB>("PlayerStatsDB");
            
            if (!string.IsNullOrEmpty(json))
            {
                var playerData = JsonUtility.FromJson<PlayerData>(json);
                m_money = playerData.money;
                //m_playerStats = playerData.playerStats;
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
            public PlayerStatsDB playerStats;
        }
    }
}
