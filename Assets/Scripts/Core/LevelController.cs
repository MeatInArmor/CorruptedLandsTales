using System;
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
        [SerializeField] private int m_additionalEnemyOnHealRoom;
        [SerializeField] private GameObject m_chestPrefab;
        
        private Vector3 m_playerSpawnOffset = new Vector3(0, 1, 0);
        private int m_roomCount = 7;
        private int m_enemyCountOnRoom;
        private int m_bossRoomIndex;
        private int m_playerRoomIndex;
        private int m_remainigEnemyRooms;
        private int m_healRoomIndex;
        private CharacterController m_characterController;
        private List<GameObject> m_prefabList = new List<GameObject>(1);

        public List<RoomComponent> rooms => m_rooms;
        
        public void SetLevelController()
        {
            RandomIndexes();
            m_prefabList.Clear();
            for (int i = 0; i < m_rooms.Count; i++)
            {
                m_rooms[i].onRoomCleared += DecreaseActiveRoom;
                if (i == m_playerRoomIndex)
                {
                    //TODO переделать потом под рут моушен
                    m_characterController.enabled = false;
                    m_player.transform.SetPositionAndRotation(m_rooms[m_playerRoomIndex].transform.position 
                                                              + m_playerSpawnOffset, m_player.transform.rotation);
                    m_characterController.enabled = true;
                    m_prefabList.Add(m_player);
                    SetRoom(m_rooms[i], "Player", m_prefabList, null, 0);
                    m_prefabList.Clear();
                }
                else
                {
                    if (i == m_bossRoomIndex)
                    {
                        m_prefabList.Add(m_bossPrefab);
                        SetRoom(m_rooms[i], "Boss", m_prefabList, m_chestPrefab, m_bossCountOnRoom);
                        m_prefabList.Clear();
                    }
                    else
                    {
                        if (i == m_healRoomIndex)
                        {
                            SetRoom(m_rooms[i], "Heal", m_enemyPrefabs, m_healItemPrefab, 
                                m_enemyCountOnRoom + m_additionalEnemyOnHealRoom);
                        }
                        else
                        {
                            SetRoom(m_rooms[i], "Enemy", m_enemyPrefabs, null, m_enemyCountOnRoom);
                        }
                    }
                }
                m_rooms[i].SpawnEnemy();
            }
        }

        private void RandomIndexes()
        {
            m_roomCount = m_rooms.Count;
            m_remainigEnemyRooms = m_roomCount - 2; //комната для босса и комната где спавнится игрок
            m_enemyCountOnRoom = m_enemyCountOnLevel / m_remainigEnemyRooms;
            m_bossRoomIndex = m_bossPossibleRoomIndexes[Random.Range(0, m_bossPossibleRoomIndexes.Length)] - 1;
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
        }

        private void SetRoom(RoomComponent room, string roomtype, List<GameObject> prefabs, 
            GameObject specialPrefab, int enemyCount) 
        {
            room.SetRoomType(roomtype);
            room.SetPrefabs(specialPrefab);
            foreach (var prefab in prefabs)
            {
                room.SetPrefabs(prefab);
            }
            room.SetEnemyCount(enemyCount);
        }

        private void OnDisable()
        {
            foreach (var room in m_rooms)
            {
                room.onRoomCleared -= DecreaseActiveRoom;
            }
        }

        private void DecreaseActiveRoom()
        {
            m_remainigEnemyRooms--;
            if (m_remainigEnemyRooms <= 0)
            {
                m_rooms[m_bossRoomIndex].OpenBossDoors();
            }
        }

        public void SetPlayer(GameObject player)
        {
            m_player = player;
        }

        public void IncreaseEnemyCount(int count)
        {
            m_enemyCountOnLevel += count;
        }
    }
}
