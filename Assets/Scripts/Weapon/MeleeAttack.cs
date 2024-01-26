using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class MeleeAttack : MonoBehaviour, IAttackItem
    {
        [SerializeField] private float m_damage = 40.0f;
        [SerializeField] private float m_attackAngle = 120.0f;
        [SerializeField] private float m_attackRange = 3.0f;
        [SerializeField] private LayerMask m_layerMask;

        [SerializeField] private float m_manaCost;
        
        private ManaComponent m_manaComponent;
        private IWeaponSkill m_weaponSkill;
        private Collider[] m_result = new Collider[10]; // ограничения строгие т.к. не меняется массив полученных значений!!!!!!
        private Transform m_parentTransform;
        
        public void Initialize(WeaponSO data)
        {
            var weaponData = data as MeleeWeaponSO;
            m_damage = weaponData.damage;
            m_attackAngle = weaponData.attackAngle;
            m_attackRange = weaponData.attackRange;
            m_layerMask = weaponData.layerMask;
            m_manaCost = weaponData.manaCost;
        }
        
        private void Awake()
        {
            m_attackAngle /= 2;
            m_parentTransform = transform.root;
            m_weaponSkill = GetComponent<IWeaponSkill>();
            m_manaComponent = GetComponentInParent<ManaComponent>();
        }

        public void Use()
        {
            Attack();
        }

        public void UseSkill() 
        {
            if (m_manaComponent.SpendMana(m_manaCost))
            {
                m_weaponSkill.Use();
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

        private void Attack()
        {
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
                float dotProductAngle = Mathf.Acos(Vector3.Dot(facingNormalized, enemyFacingNormalized)) * Mathf.Rad2Deg;
                if (damageable != null && dist < m_attackRange && dotProductAngle < m_attackAngle)
                {
                    damageable.TakeDamage(m_damage);
                    if (m_manaComponent)
                    {
                        /*m_manaComponent.GainMana(m_damage/5f);*/
                        m_manaComponent.GainMana(5);
                    }
                }
            }
        }
    }
}
