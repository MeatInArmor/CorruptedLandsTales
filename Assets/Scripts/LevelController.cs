using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private List<RandomSpawnRoom> m_rooms = new List<RandomSpawnRoom>();
        [SerializeField] private int m_enemyCountOnLevel = 28;
        [SerializeField] private int m_bossCountOnRoom = 1;
        [SerializeField] private GameObject m_bossPrefab;
        [SerializeField] private List<GameObject> m_enemyPrefabs = new List<GameObject>();
        [SerializeField] private int[] m_bossPossibleRoomIndexes;
        [SerializeField] private GameObject m_player;
        
        private int m_roomCount = 7;
        private int m_enemyCountOnRoom;
        private int m_bossRoomIndex;
        private int m_playerRoomIndex;

        private Vector3 m_playerSpawnOffset = new Vector3(0, 1, 0);
        
        private void Awake()
        {
            m_roomCount = m_rooms.Count;
            m_enemyCountOnRoom = m_enemyCountOnLevel / m_roomCount;
            m_bossRoomIndex = m_bossPossibleRoomIndexes[Random.Range(0, m_bossPossibleRoomIndexes.Length)] - 1;

            do
            {
                m_playerRoomIndex = Random.Range(0, m_roomCount);
            } while (m_playerRoomIndex == m_bossRoomIndex);
            
            for (int i = 0; i < m_rooms.Count; i++)
            {
                if (i != m_bossRoomIndex)
                {
                    if (i == m_playerRoomIndex)
                    {
                        m_player.transform.position = m_rooms[i].transform.position + m_playerSpawnOffset; // лютый костыль
                    }
                    else
                    {
                        for (int j = 0; j < m_enemyPrefabs.Count; j++)
                        {
                            m_rooms[i].SetEnemyTypes(m_enemyPrefabs[j]);
                        }
                        m_rooms[i].SetEnemyCount(m_enemyCountOnRoom);   
                    }
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
