using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class AttackManager : MonoBehaviour
    {
        private IAttackItem m_activeWeapon;

        /*public void InitializeMelee(MeleeWeaponSO weaponData)
        {
            m_activeWeapon.Hide();
            m_activeWeapon.DestroySelf();
            var item = Instantiate(weaponData.prefab, transform);
            item.Initialize(weaponData);
            m_activeWeapon = item;
            m_activeWeapon.Show();
        }*/

        public void Initialize(WeaponSO data)
        {
            if (data is MeleeWeaponSO meleeData)
            {
                EquipWeapon(meleeData);
                /*MeleeWeaponSO weaponData = data.GetComponent<MeleeWeaponSO>();
                var weaponData = data as MeleeWeaponSO;
                m_activeWeapon.Hide();
                m_activeWeapon.DestroySelf();
                var item = Instantiate(weaponData.prefab, transform);
                item.Initialize(weaponData);
                m_activeWeapon = item;
                m_activeWeapon.Show();*/
            }
            
            if (data is RangeWeaponSO rangeData)
            {
                EquipWeapon(rangeData);
                /*RangeWeaponSO weaponData = data.GetComponent<RangeWeaponSO>();
                var weaponData = data as RangeWeaponSO;
                m_activeWeapon.Hide();
                m_activeWeapon.DestroySelf();
                var item = Instantiate(weaponData.prefab, transform);
                item.Initialize(weaponData);
                m_activeWeapon = item;
                m_activeWeapon.Show();*/
            }
        }

        private void EquipWeapon<T>(T data) where T: WeaponSO
        {
            var weaponData = data;
            m_activeWeapon.Hide();
            m_activeWeapon.DestroySelf();
            var item = Instantiate(weaponData.prefab, transform);
            var attackComponent = item.GetComponent<IAttackItem>();
            attackComponent.Initialize(weaponData);
            m_activeWeapon = attackComponent;
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
