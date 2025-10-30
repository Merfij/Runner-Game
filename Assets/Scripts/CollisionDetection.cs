using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject checkpoint;
    [SerializeField] GameObject playerAnim;
    public PlayerHealth health;

    public UnityEvent RestartGame;

    private void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if(health.currentHealth > 0)
            {
                health.currentHealth--;
                player.transform.position = checkpoint.transform.position;
                Debug.Log("Health Decreased");
            }
            if (health.currentHealth <= 0)
            {
                other.GetComponent<PlayerMovement>().ActivateGameOverSreen();
                other.GetComponent<PlayerMovement>().enabled = false;
                other.GetComponentInChildren<Animator>().Play("Stumble Backwards");
                RestartGame.Invoke();
                Debug.Log("Player Died");
            }
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }
}
