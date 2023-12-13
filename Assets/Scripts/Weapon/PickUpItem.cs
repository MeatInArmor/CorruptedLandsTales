using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace CorruptedLandTales
{
    public class PickUpItem : MonoBehaviour
    {
        [SerializeField] private ScriptableObject m_data;

        public ScriptableObject GetWeaponData()
        {
            return m_data;
        }
    }
}
