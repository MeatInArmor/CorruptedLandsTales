using UnityEngine;

namespace CorruptedLandTales
{
    public class BossInit : MonoBehaviour
    {
        [SerializeField] private BossSO m_data;
        [SerializeField] private BossCharacter m_bossCharacter;

        private void Start()
        {
            if (m_bossCharacter != null)
            {
                m_bossCharacter.Initialize(m_data);
            }
        }
    }
}
