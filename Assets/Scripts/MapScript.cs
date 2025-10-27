using System.Collections;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    //private GameObject[] gameObjects;

    [SerializeField] int zPos = 60;
    [SerializeField] bool creatingMap = false;
    [SerializeField] int mapIndex;
    private int createdMap;

    public GameObject[] map_1; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (creatingMap == false)
        {
            creatingMap = true;
            StartCoroutine(MapGen());
        }
    }
    IEnumerator MapGen()
    {
        mapIndex = Random.Range(0, 4);
        Instantiate(map_1[mapIndex], new Vector3(0,1,zPos), Quaternion.identity);
        createdMap = mapIndex;
        zPos += 60;
        yield return new WaitForSeconds(4f);
        creatingMap = false;
    }
}
