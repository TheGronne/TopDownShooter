using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    float timer;
    public bool inShop = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthController>().hp < 100)
        {
            if (collision.GetComponent<HealthController>().hp <= 90)
            {
                collision.GetComponent<HealthController>().hp += 10;
            } else
            {
                collision.GetComponent<HealthController>().hp += 100 - collision.GetComponent<HealthController>().hp;
            }
        }
        Destroy(gameObject);
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
        } else
        {
            Destroy(gameObject);
        }
    }
}
