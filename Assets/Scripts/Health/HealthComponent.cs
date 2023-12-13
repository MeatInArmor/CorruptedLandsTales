using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class HealthComponent : MonoBehaviour, IDamageable
    {
        [SerializeField] private float m_health = 100f;
        [SerializeField] private int m_group = 0;
        
        private void Start()
        {
            group = m_group;
        }

        public void TakeDamage(float damage)
        {
            m_health -= damage;
            if (m_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public int group { get; set; }
    }
}