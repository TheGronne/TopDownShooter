using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    
    public int hp;
    GameObject lvl;
    public GameObject[] itemDrops = new GameObject[6];
    public GameObject deathMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                GameObject lvl = GameObject.Find("Controller");
                lvl.GetComponent<LVLControler>().SpawnedEnemies.Remove(gameObject);
                int randomSpawnChance = Random.Range(0, 100);
                if (randomSpawnChance <= 20)
                {
                    int randomItem = Random.Range(0, 100);
                    if (randomItem <= 50)
                    {
                        Instantiate(itemDrops[6], transform.position, transform.rotation);
                    } else if (randomItem <= 75)
                    {
                        Instantiate(itemDrops[1], transform.position, transform.rotation);
                    } else if (randomItem <= 100)
                    {
                        Instantiate(itemDrops[0], transform.position, transform.rotation);
                    }
                } else if (randomSpawnChance <= 21)
                {
                    int randomWeapon = Random.Range(0, 100);
                    if (randomWeapon <= 50)
                    {
                        Instantiate(itemDrops[2], transform.position, transform.rotation);
                    }
                    else if (randomWeapon <= 75)
                    {
                        Instantiate(itemDrops[3], transform.position, transform.rotation);
                    }
                    else if (randomWeapon <= 90)
                    {
                        Instantiate(itemDrops[4], transform.position, transform.rotation);
                    }
                    else if (randomWeapon <= 100)
                    {
                        Instantiate(itemDrops[5], transform.position, transform.rotation);
                    }
                }
                Destroy(gameObject);
            }
            if (gameObject.tag == "Player")
            {
                deathMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
