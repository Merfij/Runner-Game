using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerAnim;

    public UnityEvent RestartGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            other.GetComponent<PlayerMovement>().ActivateGameOverSreen();
            other.GetComponent<PlayerMovement>().enabled = false;
            other.GetComponentInChildren<Animator>().Play("Stumble Backwards");
            RestartGame.Invoke();
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }
}
