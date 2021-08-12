using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{
    public bool isTriggered = false;
    public int price;
    private void Start()
    {
        price = Random.Range(10,25);
        gameObject.GetComponent<WeaponClass>().isShopItem = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<playerController>().coins >= price)
        {
            isTriggered = true;
        }
    }
}
