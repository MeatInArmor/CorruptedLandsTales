using UnityEngine;

namespace CorruptedLandTales
{
    public class BossMuzzleComponent : MonoBehaviour
    {
        private GameObject m_player;

        private void Awake()
        {
            m_player = GameObject.Find("Player");
        }

        private void Update()
        {
            if (m_player!=null)
            {
                transform.LookAt(m_player.transform);
            }
        }
    }
}
