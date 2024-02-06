using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class SwordSkill : MonoBehaviour, IWeaponSkill
    {
        [SerializeField] private float m_damage = 40.0f;
        [SerializeField] private float m_attackRange = 6.0f;
        [SerializeField] private LayerMask m_layerMask;

        private Collider[] m_result = new Collider[10];
        private Transform m_parentTransform;
        private float m_attackAngle = 360.0f;

        private void Awake()
        {
            m_attackAngle /= 2;
            m_parentTransform = transform.root;
        }
        public void Use()
        {
            Attack();
            m_attackAngle = 360f;
        }

        private void Attack()
        {
            var count = Physics.OverlapSphereNonAlloc(transform.position, m_attackRange, m_result, m_layerMask,
                QueryTriggerInteraction.Ignore);

            for (int i = 0; i < count; i++)
            {
                var other = m_result[i];
                var damageable = other.GetComponentInParent<IDamageable>();
                Vector3 pos = m_parentTransform.position;
                Vector3 facingNormalized = m_parentTransform.forward.normalized;
                Vector3 enemyPos = other.transform.position;
                Vector3 enemyFacingNormalized = (enemyPos - pos).normalized;
                float dist = Vector3.Distance(pos, enemyPos);
                float dotProductAngle = Mathf.Acos(Vector3.Dot(facingNormalized, enemyFacingNormalized)) * Mathf.Rad2Deg;
                if (damageable != null && dist < m_attackRange && dotProductAngle < m_attackAngle)
                {
                    damageable.TakeDamage(m_damage);
                }
            }

            m_attackAngle /= 2;
        }
    }
}
