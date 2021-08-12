using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopItemScript : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] pricetagSpawnPoints;
    public GameObject[] items;
    public List<GameObject> spawnedItems = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnpoints.Length; i++)
        {
            if (GameObject.Find("Controller").GetComponent<LVLControler>().lvlCounter > 4)
            {
                int randomItem = Random.Range(4, items.Length);
                GameObject Item = Instantiate(items[randomItem], spawnpoints[i].position, spawnpoints[i].rotation);
                //Item.transform.parent = gameObject.transform;
                Item.AddComponent<triggerScript>();
                spawnedItems.Add(Item);
            } else
            {
                int randomItem = Random.Range(0, 4);
                GameObject Item = Instantiate(items[randomItem], spawnpoints[i].position, spawnpoints[i].rotation);
                //Item.transform.parent = gameObject.transform;
                Item.AddComponent<triggerScript>();
                spawnedItems.Add(Item);
            }
            
        }
    }

    private void Update()
    {
        for (int i = 0; i < spawnedItems.Count; i++)
        {
            pricetagSpawnPoints[i].GetComponent<TextMesh>().text = spawnedItems[i].GetComponent<triggerScript>().price.ToString();
            if (spawnedItems[i].GetComponent<triggerScript>().isTriggered == true)
            {
                spawnedItems.Remove(spawnedItems[i]);
                for (int ii = 0; ii < spawnedItems.Count; ii++)
                {
                    if (spawnedItems[i].GetComponent<WeaponClass>().isBought == false)
                    {
                        Destroy(spawnedItems[ii]);
                    }
                }
            }
        }
    }
}
