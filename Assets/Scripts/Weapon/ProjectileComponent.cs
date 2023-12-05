using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CorruptedLandTales
{
    public class ProjectileComponent : MonoBehaviour
    {
        [SerializeField] private float m_force = 50f;
        [SerializeField] private float m_lifeTime = 5f;
        [SerializeField] private float m_damage = 10f;

        private LayerMask m_layer;

        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * m_force, ForceMode.Impulse);
            
            Destroy(gameObject, m_lifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            var damageable = other.gameObject.GetComponentInParent<IDamageable>();
            if (damageable != null )
            {
                damageable.TakeDamage(m_damage);
            }
            Destroy(gameObject);
        }
    }
}
