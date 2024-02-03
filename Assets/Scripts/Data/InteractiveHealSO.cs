using UnityEngine;

namespace CorruptedLandTales
{
    [CreateAssetMenu(fileName = "InteractiveHealSO", menuName = "CorruptedLandTales/InteractiveHealSO")]
    public class InteractiveHealSO : InteractiveItemSO
    {
        [SerializeField] private float m_healAmount;

        public float healAmount => m_healAmount;
    }
}
