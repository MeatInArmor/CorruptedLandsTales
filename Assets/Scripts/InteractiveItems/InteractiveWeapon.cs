using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class InteractiveWeapon : MonoBehaviour, IInteractiveItem
    {
        [SerializeField] private InteractiveWeaponSO m_weaponData;
        
        public InteractiveItemSO GetData()
        {
            return m_weaponData;
        }
    }
}
