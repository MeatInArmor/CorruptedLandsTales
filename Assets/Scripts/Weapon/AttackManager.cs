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
                var meleeAttackComponent = meleeData.prefab.GetComponent<MeleeAttack>();
                meleeAttackComponent.onUseAttack += () => onUseAttack.Invoke();
            }
            
            if (data is RangeWeaponSO rangeData)
            {
                EquipWeapon(rangeData);
                var rangeAttackComponent = rangeData.prefab.GetComponent<RangeAttack>();
                rangeAttackComponent.onUseAttack += () => onUseAttack.Invoke();
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
                m_activeWeapon.Use();
            }
        }
    }
}
