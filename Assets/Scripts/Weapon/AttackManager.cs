using JetBrains.Annotations;
using UnityEngine;

namespace CorruptedLandTales
{
    public class AttackManager : MonoBehaviour
    {
        [SerializeField] private Transform m_weaponRoot;
        [SerializeField] [CanBeNull] private Animator m_Animator;

        private IAttackItem m_activeWeapon;
        private string m_activeWeaponLayer;
        private string m_activeLayerWeaponSpecial;

        public IAttackItem activeWeapon => m_activeWeapon; 

        public event System.Action onUseAttack;
        public event System.Action onUseWeaponSkill;
        public string activeWeaponLayer => m_activeWeaponLayer;
        public string activeLayerWeaponSkill => m_activeLayerWeaponSpecial;

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
            m_activeWeaponLayer = weaponData.layerAnimName;
            m_activeLayerWeaponSpecial = weaponData.layerAnimNameSpecialWeapon;
            if (m_activeWeaponLayer != "" && m_activeLayerWeaponSpecial != "")
            {
                m_Animator.SetLayerWeight(m_Animator.GetLayerIndex(m_activeWeaponLayer), 1f);
                m_Animator.SetLayerWeight(m_Animator.GetLayerIndex(m_activeLayerWeaponSpecial), 1f);
            }            
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

        public void AnimateWeaponSkill()
        {
            if (m_activeWeapon != null)
            {
                onUseWeaponSkill?.Invoke();
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
