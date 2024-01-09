using System;
using UnityEngine;

namespace CorruptedLandTales
{
    public class SpearSkill : MonoBehaviour, IWeaponSkill
    {
        [SerializeField] private GameObject m_spearPrefab; 
        private GameObject m_muzzle;

        private void Awake()
        {
            m_muzzle = GameObject.Find("ShootPoint");
        }

        public void Use()
        {
            Attack();
        }

        private void Attack()
        {
            Instantiate(m_spearPrefab, m_muzzle.transform.position, m_muzzle.transform.rotation);
        }
    }
}