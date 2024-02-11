using UnityEngine;

namespace CorruptedLandTales
{
    public class ProjectileComponent : ProjectileCore
    {
        public event System.Action onImpact;
        
        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * Force, ForceMode.Impulse);
            
            Destroy(gameObject, LifeTime);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            onImpact?.Invoke();
            Destroy(gameObject);
        }
    }
}
