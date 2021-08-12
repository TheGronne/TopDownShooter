using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    float timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<playerController>().coins++;
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
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
