using UnityEngine;

namespace CorruptedLandTales
{
    public class ExitDoorComponent : MonoBehaviour
    {
        [SerializeField] private Material m_material;
        private BoxCollider m_collider;
        private MeshRenderer m_renderer;
        private ParticleSystem m_particleSystem;
        
        public event System.Action onPlayerExitLocation;
        
        private void Awake()
        {
            m_collider = gameObject.GetComponent<BoxCollider>();
            m_renderer = gameObject.GetComponent<MeshRenderer>();
            m_material.color = new Color32(0, 0, 0, 0);
            m_particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
            m_particleSystem.Stop();
            //if (TryGetComponent(out ParticleSystem particleSystem))
            //{
            //    m_particleSystem = particleSystem;
            //}
        }
        
        public void Open() 
        {
            m_collider.enabled = true;
            m_renderer.enabled = true;
            m_collider.isTrigger = true;
            m_material.color = new Color32(0, 200, 0, 80);
            m_particleSystem.Play();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                NumbersCounts.levelsCleared++;
                onPlayerExitLocation?.Invoke();
            }
        }
    }
}
