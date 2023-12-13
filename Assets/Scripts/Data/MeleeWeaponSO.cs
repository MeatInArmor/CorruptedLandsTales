using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "MeleeWeaponSO", menuName = "CorruptedLandTales/MeleeWeaponSO")]
    public class MeleeWeaponSO : ScriptableObject
    {
        [SerializeField] private MeleeAttack m_prefab;
        [SerializeField] private float m_damage = 40.0f;
        [SerializeField] private float m_attackAngle = 120.0f;
        [SerializeField] private float m_attackRange = 3.0f;
        [SerializeField] private LayerMask m_layerMask;

        public MeleeAttack prefab => m_prefab;
        public float damage => m_damage;
        public float attackAngle => m_attackAngle;
        public float attackRange => m_attackRange;
        public LayerMask layerMask => m_layerMask;
    }
}
