using UnityEngine;

namespace CorruptedLandTales
{
    public class InteractiveHeal : MonoBehaviour, IInteractiveItem
    {
        [SerializeField] private float m_healAmount;
        
        public T GetData<T>()
        {
            return (T)(object)m_healAmount;
        }
    }
}
