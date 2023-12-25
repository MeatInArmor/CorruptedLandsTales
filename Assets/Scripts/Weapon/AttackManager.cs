using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class AttackManager : MonoBehaviour
    {
        private IAttackItem m_activeWeapon;

        public void InitializeMelee(MeleeWeaponSO weaponData)
        {
            m_activeWeapon.Hide();
            m_activeWeapon.DestroySelf();
            var item = Instantiate(weaponData.prefab, transform);
            item.Initialize(weaponData);
            m_activeWeapon = item;
            m_activeWeapon.Show();
        }

        private void Awake()
        {
            m_activeWeapon = GetComponentInChildren<IAttackItem>();
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
