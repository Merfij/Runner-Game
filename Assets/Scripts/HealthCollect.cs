using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    private PlayerHealth health;

    private void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            if (health.currentHealth == health.maxHealth)
            {
                health.currentHealth = health.maxHealth;
            }
            else
            {
                health.currentHealth++;
                Destroy(gameObject);
            }
        }
    }
}
