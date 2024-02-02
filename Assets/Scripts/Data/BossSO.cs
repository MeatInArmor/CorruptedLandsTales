using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "BossSO", menuName = "CorruptedLandTales/BossSO")]
    public class BossSO : CharacterSO
    {
        [SerializeField] private List<WeaponSO> m_attacks;

        public List<WeaponSO> attacks => m_attacks;

        public void IncreaseAttacksDamage()
        {
            foreach (var attack in m_attacks)
            {
                attack.IncreaseDamage(stats.atkData.dmg);
            }
        }
    }
}
