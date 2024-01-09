using UnityEngine;

namespace CorruptedLandTales
{
    public class ProjectileComponent : ProjectileCore
    {
        private void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            Destroy(gameObject);
        }
    }
}
