using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace CorruptedLandTales
{
    public class RangeAttack : MonoBehaviour, IAttackItem
    {
        [SerializeField] private GameObject m_prefab;
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_delay = 1f; // у противников своя задержка,
                                                     // нужно подумать что с этим сделать
        private float m_timeLastUsed;
        
        public void Initialize(WeaponSO data)
        {
            var weaponData = data as RangeWeaponSO;
            m_delay = weaponData.delay;
        }
        
        public void Attack()
        {
            float passedTime = Time.time - m_timeLastUsed; 
            if (m_delay < passedTime)
            {
                Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
                m_timeLastUsed = Time.time;
            }
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
    }
}