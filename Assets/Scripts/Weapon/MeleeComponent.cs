using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class MeleeComponent : MonoBehaviour
    {
        [SerializeField] private float m_damage = 40.0f;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Collide:{other.tag}");
            var damageable = other.GetComponentInParent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(m_damage);
            }
        }
    }
}
