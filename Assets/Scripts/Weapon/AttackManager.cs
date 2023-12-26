using Unity.VisualScripting;
using UnityEngine;

namespace CorruptedLandTales
{
    public class AttackManager : MonoBehaviour
    {
        private IAttackItem m_activeWeapon;
        
        public event System.Action onUseAttack;

        public void Initialize(WeaponSO data)
        {
            if (data is MeleeWeaponSO meleeData)
            {
                EquipWeapon(meleeData);
            }
            
            if (data is RangeWeaponSO rangeData)
            {
                EquipWeapon(rangeData);
            }
        }

        private void EquipWeapon<T>(T data) where T: WeaponSO
        {
            var weaponData = data;
            m_activeWeapon.Hide();
            m_activeWeapon.DestroySelf();
            var item = Instantiate(weaponData.prefab, transform);
            var attackComponent = item.GetComponent<IAttackItem>();
            if (item.TryGetComponent<MeleeAttack>(out MeleeAttack meleeAttack))
            {
                meleeAttack.onUseAttack += () => onUseAttack?.Invoke();
            }
            
            if (item.TryGetComponent<RangeAttack>(out RangeAttack rangeAttack))
            {
                rangeAttack.onUseAttack += () => onUseAttack?.Invoke();
            }
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
                m_activeWeapon.Use();
            }
        }
    }
}
