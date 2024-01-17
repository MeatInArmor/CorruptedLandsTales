using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedLandTales
{
    public class RandomSpawnRoom : MonoBehaviour
    {
        [SerializeField] private RandomPositions mRandomPositions;
        
        private List<GameObject> m_prefabs = new List<GameObject>();
        private List<Vector3> m_spawnPoints = new List<Vector3>();
        private int m_enemyCount;
        private int m_remainigEnemy;
        private int m_currentEnemyCount;
        
        private void Start()
        {
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
                    SpawnEnemy(m_spawnPoints[j + index], m_prefabs[i]);
                }
                m_remainigEnemy -= m_currentEnemyCount;
                index += m_currentEnemyCount;
            }
        }

        private void SpawnEnemy(Vector3 point, GameObject prefab)
        {
            Instantiate(prefab, point, transform.rotation);
        }

        public void SetEnemyCount(int count)
        {
            m_enemyCount = count;
        }

        public void SetEnemyTypes(GameObject enemyType)
        {
            m_prefabs.Add(enemyType);
        }
    }
}
