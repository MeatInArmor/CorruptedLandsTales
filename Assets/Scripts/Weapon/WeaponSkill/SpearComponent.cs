using UnityEngine;

namespace CorruptedLandTales
{
    public class SpearComponent : ProjectileCore
    {
        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.up * Force, ForceMode.Impulse);
            
            Destroy(gameObject, LifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }
    }
}