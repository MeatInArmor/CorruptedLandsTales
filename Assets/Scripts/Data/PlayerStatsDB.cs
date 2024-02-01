using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "PlayerStatsDB", menuName = "CorruptedLandTales/PlayerStatsDB")]
    public class PlayerStatsDB : ScriptableObject
    {
        [SerializeField] private List<StatSO> m_stats;

        public List<StatSO> stats => m_stats;
    }
}
