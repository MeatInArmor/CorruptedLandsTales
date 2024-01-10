using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private List<RandomSpawnRoom> m_rooms = new List<RandomSpawnRoom>();
        [SerializeField] private int m_enemyCountOnLevel = 28;
        [SerializeField] private int m_bossCountOnRoom = 1;
        [SerializeField] private GameObject m_bossPrefab;
        [SerializeField] private List<GameObject> m_enemyPrefabs = new List<GameObject>();
        
        private int m_roomCount = 7;
        private int m_enemyCountOnRoom;
        private int m_bossRoomIndex;
        
        private void Awake()
        {
            m_roomCount = m_rooms.Count;
            m_enemyCountOnRoom = m_enemyCountOnLevel / m_roomCount;
            m_bossRoomIndex = Random.Range(0, m_roomCount + 1);

            for (int i = 0; i < m_rooms.Count; i++)
            {
                if (i != m_bossRoomIndex)
                {
                    for (int j = 0; j < m_enemyPrefabs.Count; j++)
                    {
                        m_rooms[i].SetEnemyTypes(m_enemyPrefabs[j]);
                    }
                    m_rooms[i].SetEnemyCount(m_enemyCountOnRoom);
                }
                else
                {
                    m_rooms[i].SetEnemyTypes(m_bossPrefab);
                    m_rooms[i].SetEnemyCount(m_bossCountOnRoom);
                }
            }
        }
    }
}
