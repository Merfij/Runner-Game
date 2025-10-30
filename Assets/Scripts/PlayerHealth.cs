using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    private void Awake()
    {
        currentHealth = 3;
        maxHealth = 3;
    }
}
