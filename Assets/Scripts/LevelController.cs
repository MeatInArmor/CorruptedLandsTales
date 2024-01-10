using System.Collections.Generic;
using CorruptedLandTales;
using UnityEngine;

namespace CorruptedLandTales
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private List<RandomSpawnRoom> m_rooms = new List<RandomSpawnRoom>();
        [SerializeField] private int m_enemyCountOnLevel = 28;
        [SerializeField] private int m_roomCount = 7;
        
        
        private int m_enemyCountOnRoom;
        private void Awake()
        {
            m_enemyCountOnRoom = m_enemyCountOnLevel / m_roomCount;
            foreach (var room in m_rooms)
            {
                room.SetEnemyCount(m_enemyCountOnRoom);
            }
        }
    }
}
