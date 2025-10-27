using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int coinCount;
    [SerializeField] GameObject coinDisplay;

    private void Start()
    {
        coinCount = 0;
    }

    private void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
    }
}
