using UnityEngine;
using UnityEngine.Events;

    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;
        [SerializeField] UnityEvent onDeath;
        
        private void Start()
        {
            health = maxHealth;
        }

        public void Damage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                onDeath.Invoke();
            }
        }

        [ContextMenu("InstaDeath")]
        public void InstaDeath()
        {
            Damage(health);
        }
        
        public void Destroy()
        {
            Destroy(this.gameObject);
        }
        
    }
    
