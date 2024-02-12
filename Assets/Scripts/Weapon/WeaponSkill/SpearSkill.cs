using TheKiwiCoder;
using UnityEngine;

namespace CorruptedLandTales
{
    public class SpearSkill : MonoBehaviour, IWeaponSkill
    {
        [SerializeField] private GameObject m_spearPrefab;
        
        private Transform m_muzzle;
        private Vector3 m_playerOffset = new Vector3(0, 0.82f, 0);
        private void Awake()
        {
            m_muzzle = transform.root;
        }

        public void Use()
        {
            Attack();
        }

        public void SetDamage(float dmg)
        {
            if (m_spearPrefab.TryGetComponent<SpearComponent>(out SpearComponent spear))
            {
                spear.RefreshDamage(dmg);
            }
        }

        public void IncreaseDamage(float dmg)
        {
            if (m_spearPrefab.TryGetComponent<SpearComponent>(out SpearComponent spear))
            {
                spear.IncreaseDamage(dmg);
            }
        }

        private void Attack()
        {
            var muzzleTransform = m_muzzle.transform.rotation.eulerAngles;
            Quaternion rotation = Quaternion.Euler(90, muzzleTransform.y, muzzleTransform.x);
            
            Instantiate(m_spearPrefab, m_muzzle.transform.position + m_playerOffset, rotation);
        }
    }
}