using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CorruptedLandTales
{
    public class RoomComponent : MonoBehaviour
    {
        [SerializeField] private RandomPositions m_RandomPositions;
        [SerializeField] private List<RoomDoorComponent> m_doors;
        [SerializeField] private ExitDoorComponent m_exitDoor;
        [SerializeField] private RoomOnMap m_roomOnMap;

        private List<GameObject> m_prefabs = new (4);
        private List<GameObject> m_enemies = new (9);
        private List<Vector3> m_spawnPoints = new ();
        private Vector3 m_playerSpawnOffset = new (0, 1, 0);
        private int m_enemyCount = 0;
        private int m_remainigEnemy;
        private int m_currentEnemyCount;
        private string m_roomType;

        public List<GameObject> enemies => m_enemies; 
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
        
        public void SpawnEnemy()
        {
            switch (m_roomType)
            {
                case "Player":
                    m_roomOnMap.roomFieldOnMap.gameObject.SetActive(true);
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
                    m_roomOnMap.bossIconOnMap.gameObject.SetActive(true);
                    break;
                
                case "Enemy":
                    m_prefabs.RemoveAt(0);
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
                    m_roomOnMap.healingRoomOnMap.gameObject.SetActive(true);
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
            m_spawnPoints = m_RandomPositions.GetRandomRoomPoints();
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
                if (m_remainigEnemy != 0)
                {
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
                    m_roomOnMap.roomFieldOnMap.gameObject.SetActive(true);
                    m_doors.Clear();
                    onRoomCleared?.Invoke();
                    gameObject.SetActive(false);
                    
                    //m_state = RoomStatus.Deactivated;
                    break;
            }
        }

        public void SetEnemyCount(int count)
        {
            m_enemyCount = count;
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
