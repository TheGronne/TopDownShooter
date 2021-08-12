using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public Transform spawnpoint3;
    public Transform spawnpoint4;
    public Transform spawnpoint5;

    public GameObject[] items = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        int randomSpawnPoints = Random.Range(1,6);
        int randomItem = Random.Range(0, items.Length);
        switch (randomSpawnPoints)
        {
            case 1:
                GameObject item = Instantiate(items[randomItem], spawnpoint1.position, spawnpoint1.rotation);
                break;
            case 2:
                GameObject item1 = Instantiate(items[randomItem], spawnpoint2.position, spawnpoint2.rotation);
                break;
            case 3:
                GameObject item2 = Instantiate(items[randomItem], spawnpoint3.position, spawnpoint3.rotation);
                break;
            case 4:
                GameObject item3 = Instantiate(items[randomItem], spawnpoint4.position, spawnpoint4.rotation);
                break;
            case 5:
                GameObject item4 = Instantiate(items[randomItem], spawnpoint5.position, spawnpoint5.rotation);
                break;
        }
    }
}
