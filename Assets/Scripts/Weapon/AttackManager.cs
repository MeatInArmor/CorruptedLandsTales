using Unity.VisualScripting;
using UnityEngine;

namespace CorruptedLandTales
{
    public class AttackManager : MonoBehaviour
    {
        [SerializeField] private Transform m_weaponRoot;
            
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
            if (m_activeWeapon != null)
            {
                m_activeWeapon.Hide();
                m_activeWeapon.DestroySelf();
            }
            GameObject item = Instantiate(weaponData.prefab, m_weaponRoot);
            item.transform.SetParent(m_weaponRoot);
            IAttackItem attackComponent = item.GetComponent<IAttackItem>();
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

        public void AnimateUse()
        {
            if (m_activeWeapon != null)
            {
                onUseAttack?.Invoke();
            }
        }

        public void UseWeaponSkill()
        {
            if (m_activeWeapon != null)
            {
                m_activeWeapon.UseSkill();
            }
        }
    }
}
