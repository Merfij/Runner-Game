using UnityEngine;

public class SlideScript : MonoBehaviour
{
    public PlayerMovement player;

    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            other.GetComponent<Rigidbody>().AddForce(0, -500, 0);
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<PlayerMovement>().playerSpeed = 10;
        }
    }
}
