using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnEnem2 : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject[] enemies = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemyspawnpoints = GameObject.Find("EnemySpawnPoints");
        spawnpoints = new GameObject[enemyspawnpoints.transform.childCount];
        for (int i = 0; i < enemyspawnpoints.transform.childCount; i++)
        {
            spawnpoints[i] = enemyspawnpoints.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < spawnpoints.Length; i++)
        {
            int randomEnemyNumber = Random.Range(0, enemies.Length);
            GameObject enemy = Instantiate(enemies[randomEnemyNumber], spawnpoints[i].gameObject.transform.position, spawnpoints[i].gameObject.transform.rotation);
            enemy.GetComponent<HealthController>().hp += GameObject.Find("Controller").GetComponent<LVLControler>().lvlCounter * 5 - 5;
            GameObject.Find("Controller").GetComponent<LVLControler>().SpawnedEnemies.Add(enemy);
        }
        GameObject.Find("Controller").GetComponent<LVLControler>().newlvlrunning = false;
        GameObject.Find("Controller").GetComponent<LVLControler>().firstTimeCounter = 0;
    }
}
