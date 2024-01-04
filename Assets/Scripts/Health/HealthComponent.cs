using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace CorruptedLandTales
{
    public class HealthComponent : MonoBehaviour, IDamageable
    {
        [SerializeField] private float m_healthMax = 100f;
        [SerializeField] private float m_health = 100f;
        [Header("0 - Enemy, 1 - Player")]
        [SerializeField] private int m_group = 0;

        public float CurrentHealth => m_health;
        public float MaxHealth => m_healthMax;
        
        public int group { get; set; }
        
        public void Initialize(float max, float initHp)
        {
            m_healthMax = max;
            m_health = initHp;
        }
        
        private void Start()
        {
            group = m_group;
        }

        public void TakeDamage(float damage)
        {
            damage = Mathf.Min(damage, m_health);
            
            m_health -= damage;
            
            if (m_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        
    }
}