using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class MeleeAttack : MonoBehaviour
    {
        [SerializeField] private float m_damage = 40.0f;
        [SerializeField] private float m_attackAngle = 120.0f;
        [SerializeField] private float m_attackRange = 3.0f;
        [SerializeField] private LayerMask m_layerMask;
        
        private Collider[] m_result = new Collider[4];
        private float m_direction;

        private void Awake()
        {
            m_direction = m_attackAngle / 180.0f; //отношения угла к единице
        }

        public void Attack()
        {
            var count = Physics.OverlapSphereNonAlloc(transform.position,  m_attackRange, m_result, m_layerMask,
                QueryTriggerInteraction.Ignore);
            if (count > 0)
            {
                foreach (var other in m_result)
                {
                   
                    var damageable = other.GetComponentInParent<IDamageable>();
                    var itemTransform = other.transform.position;
                    Vector3 pos = transform.position;
                    Vector3 facing = transform.forward.normalized;
                    Vector3 enemyPos = other.transform.position;
                    Vector3 enemyFacing = (pos - enemyPos).normalized; //
                    float dist = Vector3.Distance(pos, enemyPos);
                    float dotProduct = Vector3.Dot(facing, enemyFacing);
                    if (damageable != null && dist < m_attackRange && dotProduct <= m_direction)
                    {
                        damageable.TakeDamage(m_damage);
                    }
                }
            }
        }
    }
}
