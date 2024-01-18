using UnityEngine;

namespace CorruptedLandTales
{
    public class SpearSkill : MonoBehaviour, IWeaponSkill
    {
        [SerializeField] private GameObject m_spearPrefab;
        [SerializeField] private float m_manaCost;
        
        private ManaComponent m_manaComponent;
        private GameObject m_muzzle;

        private void Awake()
        {
            m_muzzle = GameObject.Find("ShootPoint");
            m_manaComponent = GetComponentInParent<ManaComponent>();
        }

        public void Use()
        {
            //можно добавить доп эффекты типо поджога
            if (m_manaComponent.SpendMana(m_manaCost))
            {
                Attack();
            }
        }

        private void Attack()
        {
            Instantiate(m_spearPrefab, m_muzzle.transform.position, m_muzzle.transform.rotation);
        }
    }
}