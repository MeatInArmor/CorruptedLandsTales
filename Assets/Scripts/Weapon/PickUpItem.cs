using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace CorruptedLandTales
{
    public class PickUpItem : MonoBehaviour
    {
        [SerializeField] private ScriptableObject m_data;

        public WeaponSO GetWeaponData()
        {
            if (m_data is WeaponSO weaponData)
            {
                return weaponData;
            }

            return null;
        }
    }
}
