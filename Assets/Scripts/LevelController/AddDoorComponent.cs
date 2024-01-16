using UnityEngine;

namespace CorruptedLandTales
{
    public class AddDoorComponent : MonoBehaviour
    { 
        private BoxCollider m_collider;
        private bool m_flag = false;
        
        public bool Flag => m_flag;
        public event System.Action onEnter;

        private void Awake()
        {
            m_collider = gameObject.GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                onEnter?.Invoke();
                m_flag = true;
            }
        }
        
        public void Activate() 
        {
            m_collider.isTrigger = false;
        }
        
        public void Deactivate()
        {
            m_collider.isTrigger = true;
        }
    }
}
