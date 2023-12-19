using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class WeaponSO : ScriptableObject
    {
        [SerializeField] private GameObject m_prefab;
        
        public GameObject prefab => m_prefab;
    }
}
