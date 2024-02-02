using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "InteractiveWeaponSO", menuName = "CorruptedLandTales/InteractiveWeaponSO")]
    public class InteractiveWeaponSO : InteractiveItemSO
    {
        [SerializeField] private WeaponSO m_weapon;

        public WeaponSO weapon => m_weapon;
    }
}
