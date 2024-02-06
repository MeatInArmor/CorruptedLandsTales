using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class PlayerSettings
    {
        public Settings settings {  get; private set; } = new Settings();

        // private PlayerStatsDB m_stats = Resources.Load<PlayerStatsDB>("PlayerStatsDB");
        
        private int m_money = 1000;

        public PlayerStatsData playerStats {  get; private set; } = new PlayerStatsData();
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

            var ps = new PlayerStatsData();
            var statsSO = Resources.Load<PlayerStatsDB>("PlayerStatsDB").stats; 
            foreach (var stat in statsSO)
            {
                ps.stats.Add(new PlayerStatsData.StatData()
                {
                    statName = stat.statName,
                    level = stat.level,
                    valuePerLevel = stat.valuePerLevel,
                    cost = stat.cost,
                    costPerLevel = stat.costPerLevel,
                });
            }
            
            json = JsonUtility.ToJson(ps);
            PlayerPrefs.SetString("player.stats", json);
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
            
            json = PlayerPrefs.GetString("player.stats");
            if (!string.IsNullOrEmpty(json))
            {
                var ps = new PlayerStatsData();
                ps = JsonUtility.FromJson<PlayerStatsData>(json);
                var statsSO = Resources.Load<PlayerStatsDB>("PlayerStatsDB").stats;
                foreach (var stat in ps.stats)
                {
                    var statFromSO = statsSO.Find(x=> x.statName == stat.statName);
                    statFromSO.SetCost(stat.cost);
                    statFromSO.SetLevel(stat.level);
                    Debug.Log($"{stat.statName} {stat.cost} {stat.level}");
                }
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

        [System.Serializable]
        public class PlayerStatsData
        {
            public List<StatData> stats = new List<StatData>();

            [System.Serializable]
            public class StatData
            {
                public string statName;
                public int level;
                public float valuePerLevel;
                public int cost;
                public int costPerLevel;
            }
        }
    }
}
