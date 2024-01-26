using UnityEngine;

namespace CorruptedLandTales
{
    public class ExitDoorComponent : MonoBehaviour
    {
        private BoxCollider m_collider;
        private MeshRenderer m_renderer;
        [SerializeField] private Material m_material;
        
        public event System.Action onPlayerExitLocation;
        
        private void Awake()
        {
            m_collider = gameObject.GetComponent<BoxCollider>();
            m_renderer = gameObject.GetComponent<MeshRenderer>();
            m_material.color = Color.white;
        }
        
        public void Open() 
        {
            m_collider.enabled = true;
            m_renderer.enabled = true;
            m_collider.isTrigger = true;
            m_material.color = Color.green;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                NumbersCounts.levelsCleared++;
                onPlayerExitLocation?.Invoke();
                Debug.Log("Try to enter next location");
            }
        }
    }
}
