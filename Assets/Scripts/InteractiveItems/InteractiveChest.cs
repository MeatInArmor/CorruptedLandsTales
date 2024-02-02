using UnityEngine;

namespace CorruptedLandTales
{
    public class InteractiveChest : MonoBehaviour, IInteractiveItem
    {
        [SerializeField] private InteractiveChestSO m_chestData;

        public InteractiveItemSO GetData()
        {
            return m_chestData;
        }
    }
}
