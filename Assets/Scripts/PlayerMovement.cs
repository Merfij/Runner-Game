using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    private float maxSpeed = 30f;
    private float timer = 20f;
    private float horizontalSpeed = 5f;
    private float rightLimit = -2f;
    private float leftLimit = -10f;

    private bool canJump = true;
    private bool canSlide = true;

    [SerializeField] Rigidbody rb;
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] CapsuleCollider colliderShort;
    public float forceUp = 20;

    [SerializeField] Animator playerAnim;
    [SerializeField] GameObject gameOverScreen;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            IncreaseSpeed();
        }
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (canJump == true)
            {
                canJump = false;
                playerAnim.SetBool("canJump", true);
                rb.AddForce(Vector3.up * forceUp);
                StartCoroutine(CancelJump());
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (canSlide == true)
            {
                canSlide = false;
                playerAnim.SetBool("canSlide", true);
                rb.AddForce(Vector3.down * 200);
                capsuleCollider.enabled = false;
                colliderShort.enabled = true;
                StartCoroutine(CancelSlide());
            }
        }
    }
    IEnumerator CancelJump()
    {
        yield return new WaitForSeconds(0.4f);
        playerAnim.SetBool("canJump", false);
        canJump = true;
    }

    IEnumerator CancelSlide()
    {
        yield return new WaitForSeconds(0.4f);
        playerAnim.SetBool("canSlide", false);
        capsuleCollider.enabled = true;
        colliderShort.enabled = false;
        canSlide = true;
    }
    private void IncreaseSpeed()
    {
        if(playerSpeed != maxSpeed)
        {
            playerSpeed++;
        } else
        {
            playerSpeed = maxSpeed;
        }
        timer = 20f;
    }

    public void ActivateGameOverSreen()
    {
        gameOverScreen.SetActive(true);
    }
}
