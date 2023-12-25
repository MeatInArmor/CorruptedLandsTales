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
        private int m_meleeCount;
        
        private void Start()
        {
            m_spawnPoints = m_meshSpawn.GetRandomRoomPoints();
            m_rangeCount = Random.Range(1, m_enemyCount);
            m_meleeCount = Random.Range(1, m_enemyCount - m_rangeCount + 1);
            
            for (int i = 0; i < m_rangeCount; i++)
            {
                SpawnEnemy(m_spawnPoints[i], m_rangePrefab);
            }
            
            for (int i = 0; i < m_meleeCount; i++)
            {
                int index = i + m_rangeCount;
                SpawnEnemy(m_spawnPoints[index], m_meleePrefab);
            }
        }

        private void SpawnEnemy(Vector3 point, GameObject prefab)
        {
            Instantiate(prefab, point, transform.rotation);
        }
        
    }
}
