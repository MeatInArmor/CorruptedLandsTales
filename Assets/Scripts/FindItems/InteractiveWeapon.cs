using UnityEngine;

namespace CorruptedLandTales
{
    public class InteractiveWeapon : MonoBehaviour, IInteractiveItem
    {
        [SerializeField] private ScriptableObject m_data;

        public T GetData<T>()
        {
            return (T)(object)m_data;
        }
    }
}
