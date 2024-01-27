using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CorruptedLandTales
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> m_enemyPrefabs = new List<GameObject>();
        [SerializeField] private GameObject m_bossPrefab;
        [SerializeField] private GameObject m_player;
        [SerializeField] private List<RoomComponent> m_rooms = new List<RoomComponent>();
        [SerializeField] private int[] m_bossPossibleRoomIndexes;
        [SerializeField] private int m_enemyCountOnLevel = 28;
        [SerializeField] private int m_bossCountOnRoom = 1;
        [SerializeField] private GameObject m_healItemPrefab;
        [SerializeField] private GameObject m_chestPrefab;
        
        private Vector3 m_playerSpawnOffset = new Vector3(0, 1, 0);
        private int m_roomCount = 7;
        private int m_enemyCountOnRoom;
        private int m_bossRoomIndex;
        private int m_playerRoomIndex;
        private int m_remainigEnemyRooms;
        private int m_healRoomIndex;
        private CharacterController m_characterController;

        public List<RoomComponent> rooms => m_rooms;
        
        //TODO надо разбить потом на функции и подфункции всю логику
        //и отдельно как то вынести "особые префабы" типа хила и сундуков
        
        private void Awake()
        {
            m_roomCount = m_rooms.Count;
            m_remainigEnemyRooms = m_roomCount - 2; //комната для босса и комната где спавнится игрок
            m_enemyCountOnRoom = m_enemyCountOnLevel / m_remainigEnemyRooms;
            m_bossRoomIndex = m_bossPossibleRoomIndexes[Random.Range(0, m_bossPossibleRoomIndexes.Length)] - 1;
            
            if (m_player == null)
            {
                m_player = GameObject.Find("Player");
            }
            if (!m_characterController)
            {
                m_characterController = m_player.GetComponent<CharacterController>();
            }

            do
            {
                m_playerRoomIndex = Random.Range(0, m_roomCount);
            } while (m_playerRoomIndex == m_bossRoomIndex);

            do
            {
                m_healRoomIndex = Random.Range(0, m_roomCount);
            } while (m_healRoomIndex == m_bossRoomIndex || m_healRoomIndex == m_playerRoomIndex);
            
            for (int i = 0; i < m_rooms.Count; i++)
            {
                m_rooms[i].onRoomCleared += () =>
                {
                    m_remainigEnemyRooms--;
                    if (m_remainigEnemyRooms <= 0)
                    {
                        m_rooms[m_bossRoomIndex].OpenBossDoors();
                    }
                };
                
                if (i != m_bossRoomIndex)
                {
                    if (i == m_playerRoomIndex)
                    {
                        m_characterController.enabled = false;
                        m_player.transform.SetPositionAndRotation(m_rooms[m_playerRoomIndex].transform.position 
                                                                  + m_playerSpawnOffset, m_player.transform.rotation);
                        m_characterController.enabled = true;
                        m_rooms[i].SetRoomType("Player");
                        m_rooms[i].SetPrefabs(m_player);
                    }
                    else
                    {
                        if (i == m_healRoomIndex)
                        {
                            m_rooms[i].SetRoomType("Heal");
                            m_rooms[i].AddEnemyCount(2); //дополнительное количество врагов в комнате с хилом
                            m_rooms[i].SetPrefabs(m_healItemPrefab);
                        }
                        else
                        {
                            m_rooms[i].SetRoomType("Enemy");
                        }
                        for (int j = 0; j < m_enemyPrefabs.Count; j++)
                        {
                            m_rooms[i].SetPrefabs(m_enemyPrefabs[j]);
                        }
                        m_rooms[i].AddEnemyCount(m_enemyCountOnRoom);
                    }
                }
                else
                {
                    m_rooms[i].SetRoomType("Boss");
                    m_rooms[i].SetPrefabs(m_chestPrefab); 
                    m_rooms[i].SetPrefabs(m_bossPrefab);
                    m_rooms[i].AddEnemyCount(m_bossCountOnRoom);
                }
            }
        }
    }
}
