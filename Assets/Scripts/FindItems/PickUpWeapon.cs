using UnityEngine;

namespace CorruptedLandTales
{
    public class PickUpWeapon : MonoBehaviour, IUsableItem
    {
        [SerializeField] private ScriptableObject m_data;

        public T GetData<T>()
        {
            return (T)(object)m_data;
        }
    }
}
