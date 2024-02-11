using UnityEngine;

namespace CorruptedLandTales
{
    public class WeaponSO : ScriptableObject
    {
        [SerializeField] private GameObject m_prefab;
        [SerializeField] private float m_damage;
        [SerializeField] private string m_layerAnimName;
        [SerializeField] private string m_layerAnimNameSpecialWeapon;
        [SerializeField] private float m_skillDamage = 100;

        public GameObject prefab => m_prefab;
        public float damage => m_damage;
        public string layerAnimName => m_layerAnimName;
        public string layerAnimNameSpecialWeapon => m_layerAnimNameSpecialWeapon;
        public float skillDamage => m_skillDamage;
        
        public void IncreaseDamage(float dmg)
        {
            m_damage += dmg;
        }

        public void SetDamage(float dmg)
        {
            m_damage = dmg;
        }
    }
}
