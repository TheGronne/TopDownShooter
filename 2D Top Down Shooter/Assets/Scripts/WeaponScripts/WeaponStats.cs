using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public int damage;
    public int itemID;
    public float bulletSpeed;
    public float bulletCooldown;
    public int ammo;
    public string element;
    public GameObject bullet;
    public float destroyBulletTimer;

    private void Update()
    {
        if (ammo <= 0)
        {
            GameObject.Find("Player").GetComponent<playerController>().weapons.Remove(gameObject);
            if (GameObject.Find("Player").GetComponent<playerController>().weapons.Count == 0)
            {
                GameObject.Find("Player").GetComponent<playerController>().itemID = 0;
            }
            Destroy(gameObject);
        }
    }
}
