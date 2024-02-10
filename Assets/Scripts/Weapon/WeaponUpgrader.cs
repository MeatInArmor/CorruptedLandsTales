using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class WeaponUpgrader : MonoBehaviour
    {
        [SerializeField] private GameController m_gameController;
        [SerializeField] private List<WeaponSO> m_weapons;
        [SerializeField] private List<WeaponSO> m_presetWeapons;
        [SerializeField] private List<GameObject> m_weaponPrefabs;
        [SerializeField] private float m_damageToIncrease = 30f;
        
        public float damageToIncrease => m_damageToIncrease;
        
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
                if (m_weaponPrefabs[i].TryGetComponent<IWeaponSkill>(out IWeaponSkill weaponSkill))
                {
                    weaponSkill.SetDamage(m_weapons[i].skillDamage);
                }
            }
        }
        
        private void IncreaseStats()
        {
            for (int i = 0; i < m_weapons.Count; i++)
            {
                m_weapons[i].IncreaseDamage(m_damageToIncrease);
                if (m_weaponPrefabs[i].TryGetComponent<IWeaponSkill>(out IWeaponSkill weaponSkill))
                {
                    weaponSkill.IncreaseDamage(m_damageToIncrease);
                }
            }
        }
    }
}
