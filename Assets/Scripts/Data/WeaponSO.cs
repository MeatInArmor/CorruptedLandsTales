using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class WeaponSO : ScriptableObject
    {
        [SerializeField] private GameObject m_prefab;
        [SerializeField] private float m_damage;
        
        public GameObject prefab => m_prefab;
        public float damage => m_damage;

        public void IncreaseDamage(float dmg)
        {
            m_damage += dmg;
        }

        public void SetDamage(float dmg)
        {
            m_damage = dmg;
        }
    }
}
