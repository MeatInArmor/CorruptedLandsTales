using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CorruptedLandTales
{
    public class WeaponChest : MonoBehaviour
    {
        [SerializeField] private List<GameObject> m_spawnWeapons;

        private int m_index;

        private void Start()
        {
            m_index = Random.Range(0, m_spawnWeapons.Count);

            var weapon = Instantiate(m_spawnWeapons[m_index], transform.position, transform.rotation);
        }
    }
}
