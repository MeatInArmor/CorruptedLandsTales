using UnityEngine;

namespace CorruptedLandTales
{
    public class PickUpItem : MonoBehaviour
    {
        [SerializeField] private ScriptableObject m_data;
        [SerializeField] private float m_healAmount;

        public WeaponSO GetWeaponData()
        {
            if (m_data is WeaponSO weaponData)
            {
                Destroy(gameObject);
                return weaponData;
            }
            return null;
        }

        public float GetHealth()
        {
            Destroy(gameObject);
            return m_healAmount;
        }
    }
}
