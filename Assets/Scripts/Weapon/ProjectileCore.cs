using UnityEngine;

namespace CorruptedLandTales
{
    public class ProjectileCore : MonoBehaviour
    {
        [SerializeField] private float m_force = 50f;
        [SerializeField] private float m_lifeTime = 5f;
        [SerializeField] private float m_damage = 10f;
        [SerializeField] private int m_group = 0; //0 enemy 1 player

        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * m_force, ForceMode.Impulse);
            
            Destroy(gameObject, m_lifeTime);
        }

        public void OnTriggerEnter(Collider other)
        {
            var damageable = other.gameObject.GetComponentInParent<IDamageable>();
            if (damageable != null && m_group == damageable.group)
            {
                damageable.TakeDamage(m_damage);
            }
        }
    }
}