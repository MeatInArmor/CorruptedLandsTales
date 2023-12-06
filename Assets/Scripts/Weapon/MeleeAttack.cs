using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class MeleeAttack : MonoBehaviour, IAttackItem
    {
        [SerializeField] private float m_damage = 40.0f;
        [SerializeField] private float m_attackAngle = 120.0f;
        [SerializeField] private float m_attackRange = 3.0f;
        [SerializeField] private LayerMask m_layerMask;
        
        private Collider[] m_result = new Collider[10]; // ограничения строгие т.к. не меняется массив полученных значений!!!!!!
        private Transform m_parentTransform;
        private MeleeAttackAnimation m_anim;
        
        /*public void Initialize(MeleeWeaponSO weaponData)
        {
            m_damage = weaponData.damage;
            m_attackAngle = weaponData.attackAngle;
            m_attackRange = weaponData.attackRange;
            m_layerMask = weaponData.layerMask;
        }*/
        
        private void Awake()
        {
            m_attackAngle /= 2;
            m_parentTransform = GetComponentInParent<Transform>();
            m_anim = GetComponent<MeleeAttackAnimation>();
        }

        public void Attack()
        {
            m_anim.AttackAnimation();
            
            var count = Physics.OverlapSphereNonAlloc(transform.position,  m_attackRange, m_result, m_layerMask,
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
                Debug.Log($"{dist}");
                float dotProductAngle = Mathf.Acos(Vector3.Dot(facingNormalized, enemyFacingNormalized)) * Mathf.Rad2Deg;
                Debug.Log($"{dotProductAngle}");
                if (damageable != null && dist < m_attackRange && dotProductAngle < m_attackAngle)
                {
                    damageable.TakeDamage(m_damage);
                }
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
