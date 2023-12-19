using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "RangeWeaponSO", menuName = "CorruptedLandTales/RangeWeaponSO")]

    public class RangeWeaponSO : WeaponSO
    {
        /*[SerializeField] private GameObject m_prefab;*/
        //[SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_delay = 1f;
        
        /*public GameObject prefab => m_prefab;*/
        //public Transform muzzle => m_muzzle;
        public float delay => m_delay;
    }
}
