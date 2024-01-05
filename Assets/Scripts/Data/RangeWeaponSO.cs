using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "RangeWeaponSO", menuName = "CorruptedLandTales/RangeWeaponSO")]

    public class RangeWeaponSO : WeaponSO
    {
        [SerializeField] private float m_delay = 1f;
        public float delay => m_delay;
    }
}
