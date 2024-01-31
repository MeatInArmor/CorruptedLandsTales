using System;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class WeaponUpgrader : MonoBehaviour
    {
        [SerializeField] private GameController m_gameController;
        [SerializeField] private List<WeaponSO> m_weapons;
        [SerializeField] private List<WeaponSO> m_presetWeapons;
        [SerializeField] private float m_damageToIncrease = 30f;

        private void Start()
        {
            m_gameController.onLevelCleared += IncreaseStats;
        }
        
        private void OnDisable()
        {
            m_gameController.onLevelCleared -= IncreaseStats;
        }
        
        private void Awake()
        {
            for (int i = 0; i < m_weapons.Count; i++)
            {
                m_weapons[i].SetDamage(m_presetWeapons[i].damage);
            }
        }
        
        private void IncreaseStats()
        {
            for (int i = 0; i < m_weapons.Count; i++)
            {
                m_weapons[i].IncreaseDamage(m_damageToIncrease);
            }
        }
    }
}
