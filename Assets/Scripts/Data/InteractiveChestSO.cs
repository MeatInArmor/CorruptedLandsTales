using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "InteractiveChestSO", menuName = "CorruptedLandTales/InteractiveChestSO")]
    public class InteractiveChestSO : InteractiveItemSO
    {
        [SerializeField] private List<GameObject> m_weapons;

        public List<GameObject> weapons => m_weapons;
    }
}
