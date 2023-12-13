using System.Collections;
using System.Collections.Generic;
using CorruptedLandTales;
using Unity.VisualScripting;
using UnityEngine;

namespace CorruptedLandTales
{
    public class RandomSpawnRoom : MonoBehaviour
    {
        [SerializeField] private GameObject m_meleePrefab;
        [SerializeField] private GameObject m_rangePrefab;
        [SerializeField] private MeshSpawn m_meshSpawn;
        [SerializeField] private int m_enemyCount = 4;
        
        private List<Vector3> m_spawnPoints = new List<Vector3>();
        private int m_rangeCount;
        
        private void Start()
        {
            m_spawnPoints = m_meshSpawn.GetRandomRoomPoints();
            m_rangeCount = Random.Range(1, m_enemyCount);
            for (int i = 0; i < m_enemyCount; i++)
            {
                if (i < m_rangeCount)
                {
                    SpawnEnemy(m_spawnPoints[i], m_rangePrefab);
                }
                else
                {
                    SpawnEnemy(m_spawnPoints[i], m_meleePrefab);
                }
            }
        }

        private void SpawnEnemy(Vector3 point, GameObject prefab)
        {
            Instantiate(prefab, point, transform.rotation);
        }
        
    }
}
