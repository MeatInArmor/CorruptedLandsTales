using UnityEngine;

namespace CorruptedLandTales
{
    public class ProjectileComponent : ProjectileCore
    {
        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * Force, ForceMode.Impulse);
            
            Destroy(gameObject, LifeTime);
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            Destroy(gameObject);
        }
    }
}
