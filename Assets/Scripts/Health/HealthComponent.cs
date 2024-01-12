using UnityEngine;
using UnityEngine.Events;

namespace CorruptedLandTales
{
    public class HealthComponent : MonoBehaviour, IDamageable
    {
        [SerializeField] private float m_healthMax = 100f;
        [SerializeField] private float m_health = 100f;
        [SerializeField] private UnityEvent m_onDie;
        [Header("0 - Enemy, 1 - Player")]
        [SerializeField] private int m_group = 0;
        

        public float CurrentHealth => m_health;
        public bool isFullHealth => m_health == m_healthMax;
        public float healthPercent => m_health / m_healthMax;
        public float MaxHealth => m_healthMax;
        public event System.Action<float> onTakeDamage;
        public event System.Action onDie;

        public int group { get; set; }
        
        public void Initialize(float max, float initHp)
        {
            m_healthMax = max;
            m_health = initHp;
            onTakeDamage?.Invoke(0);

        }

        private void Start()
        {
            group = m_group;
        }

        public void TakeDamage(float damage)
        {
            damage = Mathf.Min(damage, m_health);
            m_health -= damage;
            onTakeDamage?.Invoke(damage);

            if (m_health <= 0)
            {                
                Debug.Log("Die");
                onDie?.Invoke();
                m_onDie.Invoke();
                //Destroy(gameObject);
            }
        }

        
    }
}