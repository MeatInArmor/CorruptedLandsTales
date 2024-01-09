using UnityEngine;

namespace CorruptedLandTales
{
    public class SpearSkill : MonoBehaviour, IWeaponSkill
    {
        [SerializeField] private GameObject m_spearPrefab;
        [SerializeField] private Transform m_muzzle;
        
        public void Use()
        {
            Attack();
        }

        private void Attack()
        {
            Instantiate(m_spearPrefab, m_muzzle.position, m_muzzle.rotation);
        }
    }
}