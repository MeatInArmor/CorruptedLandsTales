using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "ChestSO", menuName = "CorruptedLandTales/ChestSO")]
    public class ChestSO : ScriptableObject
    {
        [SerializeField] private List<GameObject> m_weapons;

        public List<GameObject> weapons => m_weapons;
    }
}
