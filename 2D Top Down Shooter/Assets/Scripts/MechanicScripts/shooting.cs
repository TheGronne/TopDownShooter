using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 15f;
    public float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && cooldown <= 0)
        {
            shoot();
        }
    }

    void shoot()
    {
        if (gameObject.GetComponent<playerController>().usingItem == false)
        {
            bulletForce = 20f;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            cooldown = 0.5f;
            bullet.GetComponent<bulletScript>().destroyTimer = 10;
        } 
        else if (gameObject.GetComponent<playerController>().itemID > 0)
        {
            bulletForce = gameObject.GetComponent<playerController>().weapons[gameObject.GetComponent<swapItems>().currentWeapon - 1].GetComponent<WeaponStats>().bulletSpeed;
            GameObject bullet = Instantiate(gameObject.GetComponent<playerController>().weapons[gameObject.GetComponent<swapItems>().currentWeapon - 1].GetComponent<WeaponStats>().bullet, firePoint.position, firePoint.rotation);
            bullet.GetComponent<DamageController>().element = gameObject.GetComponent<playerController>().weapons[gameObject.GetComponent<swapItems>().currentWeapon - 1].GetComponent<WeaponStats>().element;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            bullet.GetComponent<DamageController>().damage = gameObject.GetComponent<playerController>().weapons[gameObject.GetComponent<swapItems>().currentWeapon - 1].GetComponent<WeaponStats>().damage;
            cooldown = gameObject.GetComponent<playerController>().weapons[gameObject.GetComponent<swapItems>().currentWeapon - 1].GetComponent<WeaponStats>().bulletCooldown;
            gameObject.GetComponent<playerController>().weapons[gameObject.GetComponent<swapItems>().currentWeapon - 1].GetComponent<WeaponStats>().ammo -= 1;
            bullet.GetComponent<bulletScript>().destroyTimer = gameObject.GetComponent<playerController>().weapons[gameObject.GetComponent<swapItems>().currentWeapon - 1].GetComponent<WeaponStats>().destroyBulletTimer;
        } 
    }
}
