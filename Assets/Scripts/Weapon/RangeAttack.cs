using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class RangeAttack : MonoBehaviour, IAttackItem
    {
        [SerializeField] private GameObject m_projectilePrefab;
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_delay = 1f; 
        
        public void Initialize(WeaponSO data)
        {
            var weaponData = data as RangeWeaponSO;
            m_delay = weaponData.delay;
        }

        public void UseSkill()
        {
            throw new System.NotImplementedException();
        }

        public void Use()
        {
            Attack();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }

        private void Attack()
        {
            Instantiate(m_projectilePrefab, m_muzzle.position, m_muzzle.rotation);
        }
    }
}