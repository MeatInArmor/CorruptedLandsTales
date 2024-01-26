using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace CorruptedLandTales
{
    public class RoomComponent : MonoBehaviour
    {
        [SerializeField] private RandomPositions mRandomPositions;
        [SerializeField] private List<RoomDoorComponent> m_doors;
        [SerializeField] private ExitDoorComponent m_exitDoor;
        
        private List<GameObject> m_prefabs = new List<GameObject>();
        private List<GameObject> m_enemies = new List<GameObject>(9);
        private List<Vector3> m_spawnPoints = new List<Vector3>();
        private Vector3 m_playerSpawnOffset = new Vector3(0, 1, 0);
        private int m_enemyCount = 0;
        private int m_remainigEnemy;
        private int m_currentEnemyCount;
        private string m_roomType;
        
        public event System.Action onRoomCleared;

        private RoomStatus m_state;
        private enum RoomStatus
        {
            Deactivated,
            Activating,
            InCombat,
            Deactivating
        }
        //TODO можно отрефакторить в нормальный StateMachine
        private void Start()
        {
            switch (m_roomType) // при необходимости можно будет добавить что то в каждый тип
            {
                case "Player":
                    /*m_prefabs[0].transform.SetLocalPositionAndRotation(transform.position + m_playerSpawnOffset,
                        m_prefabs[0].transform.rotation);*/ 
                    gameObject.SetActive(false);
                    break;
                
                case "Boss":
                    var chest = Instantiate(m_prefabs[0], transform.position + m_playerSpawnOffset,
                        m_prefabs[0].transform.rotation);
                    chest.SetActive(false);
                    foreach (var door in m_doors)
                    {
                        door.Activate();
                        door.SetDoorFlag(true);
                    }
                    onRoomCleared += () =>
                    {
                        m_exitDoor.Open();
                        chest.SetActive(true);
                    };
                    m_prefabs.RemoveAt(0);
                    break;
                
                case "Enemy":
                    break;
                
                case "Heal":
                    var heal = Instantiate(m_prefabs[0], transform.position + m_playerSpawnOffset,
                        m_prefabs[0].transform.rotation);
                    heal.SetActive(false);
                    onRoomCleared += () =>
                    {
                        heal.SetActive(true);
                    };
                    m_prefabs.RemoveAt(0);
                    break;
            }
            
            m_state = RoomStatus.Deactivated;
            foreach (var door in m_doors)
            {
                door.onPlayerEnter += () =>
                {
                    m_state = RoomStatus.Activating;
                };
            }
            
            m_spawnPoints = mRandomPositions.GetRandomRoomPoints();
            m_remainigEnemy = m_enemyCount;
            int index = 0;
            
            for (int i = 0; i < m_prefabs.Count; i++)
            {
                if (i == m_prefabs.Count - 1)
                {
                    m_currentEnemyCount = m_remainigEnemy;
                }
                else
                {
                    m_currentEnemyCount = Random.Range(1, m_remainigEnemy + 1);
                }
                for (int j = 0; j < m_currentEnemyCount; j++)
                {
                    var enemy = Instantiate(m_prefabs[i], m_spawnPoints[j + index], transform.rotation);
                    m_enemies.Add(enemy);
                    enemy.SetActive(false);
                    if (enemy.TryGetComponent<HealthComponent>(out HealthComponent healthComponent))
                    {
                        healthComponent.onDie += () => { m_enemyCount -= 1; };
                    }
                }
                m_remainigEnemy -= m_currentEnemyCount;
                index += m_currentEnemyCount;
            }
        }

        private void Update()
        {
            switch (m_state)
            {
                case RoomStatus.Deactivated:
                    break;
                
                case RoomStatus.Activating:
                    foreach (var door in m_doors)
                    {
                        door.Activate();
                    }
                    foreach (var enemy in m_enemies)
                    {
                        enemy.SetActive(true);
                    }
                    m_state = RoomStatus.InCombat;
                    break;
                
                case RoomStatus.InCombat:
                    if (m_enemyCount <= 0)
                    {
                        m_state = RoomStatus.Deactivating;
                    }
                    break;
                
                case RoomStatus.Deactivating:
                    foreach (var door in m_doors)
                    {
                        door.Deactivate();
                    }
                    m_doors.Clear();
                    onRoomCleared?.Invoke();
                    gameObject.SetActive(false);
                    //m_state = RoomStatus.Deactivated;
                    break;
            }
        }

        public void AddEnemyCount(int count)
        {
            m_enemyCount += count;
        }

        public void SetPrefabs(GameObject enemyType)
        {
            m_prefabs.Add(enemyType);
        }

        public void SetRoomType(string type)
        {
            m_roomType = type;
        }

        public void OpenBossDoors()
        {
            foreach (var door in m_doors)
            {
                door.SetDoorFlag(false);
                door.Deactivate();
            }
        }
    }
}
