using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.coinCount++;
        gameObject.SetActive(false);
    }
}
