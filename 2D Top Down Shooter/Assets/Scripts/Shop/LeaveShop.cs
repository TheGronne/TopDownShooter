using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveShop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < GameObject.Find("Controller").GetComponent<LVLControler>().currentShop.GetComponent<shopItemScript>().spawnedItems.Count; i++)
            {
                if (GameObject.Find("Controller").GetComponent<LVLControler>().currentShop.GetComponent<shopItemScript>().spawnedItems[i].GetComponent<WeaponClass>().isBought == false)
                {
                    Destroy(GameObject.Find("Controller").GetComponent<LVLControler>().currentShop.GetComponent<shopItemScript>().spawnedItems[i]);
                }
            }
            Destroy(GameObject.Find("Controller").GetComponent<LVLControler>().currentShop);
            GameObject.Find("Controller").GetComponent<LVLControler>().newlvl();
            //GameObject.Find("Controller").GetComponent<LVLControler>().firstTimeCounter = 0;
        }
    }
}
