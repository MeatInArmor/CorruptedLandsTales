using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class AttackManager : MonoBehaviour
    {
        private IAttackItem m_activeWeapon;

        /*public void Initialize(IReadOnlyList<MeleeWeaponSO> weaponData)
        {
            var item = Instantiate(weaponData.prefab, transform);
            item.
        }*/

        private void Awake()
        {
            m_activeWeapon = GetComponentInChildren<IAttackItem>(); //пока так, потом переделать
        }

        public void UseWeapon()
        {
            if (m_activeWeapon != null)
            {
                m_activeWeapon.Attack();
            }
        }
    }
}
