using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int coinCount;
    [SerializeField] GameObject coinDisplay;
    [SerializeField] GameObject healthDisplay;
    public PlayerHealth health;

    private void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        coinCount = 0;
    }

    private void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
        healthDisplay.GetComponent<TMPro.TMP_Text>().text = "Health: " + health.currentHealth;
    }
}
