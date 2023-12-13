using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "RangeWeaponSO", menuName = "CorruptedLandTales/RangeWeaponSO")]

    public class RangeWeaponSO : ScriptableObject
    {
        [SerializeField] private RangeAttack m_prefab;
        //[SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_delay = 1f;
        
        public RangeAttack prefab => m_prefab;
        //public Transform muzzle => m_muzzle;
        public float delay => m_delay;
    }
}
