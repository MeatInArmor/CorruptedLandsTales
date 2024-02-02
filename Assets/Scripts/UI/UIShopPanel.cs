using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class UIShopPanel : MonoBehaviour
    {
        public event System.Action<string> onTryBuyItem;
        
        [SerializeField] private UIShopItem m_healthStat;
        [SerializeField] private UIShopItem m_damageStat;
        [SerializeField] private UIShopItem m_speedStat;
        [SerializeField] private UIShopItem m_attackSpeedStat;
        [SerializeField] private UIShopItem m_manaPoolStat;
        [SerializeField] private UIShopItem m_manaRegenStat;
        [SerializeField] private UIBuyBtn m_buyBtn;
        [SerializeField] private TMP_Text m_cost;
        [SerializeField] private TMP_Text m_type;
        private List<StatSO> m_playerStats;

        //TODO переписать этот говнокод
        public void SetPlayerStatsAndShopItems(PlayerStatsDB playerStatsDB)
        {
            ClearText();
            m_buyBtn.onClickBuyButton += OnBuyClick;
            m_playerStats = playerStatsDB.stats;
            foreach (var stat in m_playerStats)
            {
                if (stat.statName == "health")
                {
                    m_healthStat.SetUpShopItem("health", stat.cost, stat.level);
                    m_healthStat.onClick += OnItemClick;
                }
                if (stat.statName == "attack")
                {
                    m_damageStat.SetUpShopItem("attack", stat.cost, stat.level);
                    m_damageStat.onClick += OnItemClick;
                }
                if (stat.statName == "attackspeed")
                {
                    m_attackSpeedStat.SetUpShopItem("attackspeed", stat.cost, stat.level);
                    m_attackSpeedStat.onClick += OnItemClick;
                }
                if (stat.statName == "manapool")
                {
                    m_manaPoolStat.SetUpShopItem("manapool", stat.cost, stat.level);
                    m_manaPoolStat.onClick += OnItemClick;
                }
                if (stat.statName == "manaregen")
                {
                    m_manaRegenStat.SetUpShopItem("manaregen", stat.cost, stat.level);
                    m_manaRegenStat.onClick += OnItemClick;
                }
                if (stat.statName == "speed")
                {
                    m_speedStat.SetUpShopItem("speed", stat.cost, stat.level);
                    m_speedStat.onClick += OnItemClick;
                }
            }
        }

        private void OnItemClick(string type, int cost)
        {
            m_cost.text = cost.ToString();
            m_type.text = type;
        }
        
        private void OnBuyClick()
        {
            onTryBuyItem?.Invoke(m_type.text);
        }

        private void OnDisable() // переписать этот говнокод
        {
            m_healthStat.onClick -= OnItemClick;
            m_damageStat.onClick -= OnItemClick;
            m_speedStat.onClick -= OnItemClick;
            m_attackSpeedStat.onClick -= OnItemClick;
            m_manaPoolStat.onClick -= OnItemClick;
            m_manaRegenStat.onClick -= OnItemClick;
            m_buyBtn.onClickBuyButton -= OnBuyClick;
            ClearText();
        }

        private void ClearText()
        {
            m_cost.text = "";
            m_type.text = "";
        }
    }
}
