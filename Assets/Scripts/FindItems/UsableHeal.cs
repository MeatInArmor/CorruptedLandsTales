using UnityEngine;

namespace CorruptedLandTales
{
    public class UsableHeal : MonoBehaviour, IUsableItem
    {
        [SerializeField] private float m_healAmount;
        
        public T GetData<T>()
        {
            return (T)(object)m_healAmount;
        }
    }
}
