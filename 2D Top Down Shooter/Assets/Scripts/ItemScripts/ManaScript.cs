using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScript : MonoBehaviour
{
    float timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < collision.gameObject.GetComponent<playerController>().weapons.Count; i++)
            {
                collision.gameObject.GetComponent<playerController>().weapons[i].GetComponent<WeaponStats>().ammo += 5;
            }
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        timer = 10;
    }

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
