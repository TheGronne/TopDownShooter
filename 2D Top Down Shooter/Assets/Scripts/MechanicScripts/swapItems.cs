using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapItems : MonoBehaviour
{
    public int currentWeapon;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWeapon > player.GetComponent<playerController>().weapons.Count)
        {
            currentWeapon = player.GetComponent<playerController>().weapons.Count;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeapon == 1)
            {
                player.GetComponent<playerController>().weapons[currentWeapon - 1].GetComponent<WeaponClass>().itemUsing = false;
                currentWeapon = player.GetComponent<playerController>().weapons.Count;
                player.GetComponent<playerController>().weapons[currentWeapon - 1].GetComponent<WeaponClass>().itemUsing = true;
            } else
            {
                player.GetComponent<playerController>().weapons[currentWeapon - 1].GetComponent<WeaponClass>().itemUsing = false;
                currentWeapon -= 1;
                player.GetComponent<playerController>().weapons[currentWeapon - 1].GetComponent<WeaponClass>().itemUsing = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentWeapon == player.GetComponent<playerController>().weapons.Count)
            {
                player.GetComponent<playerController>().weapons[currentWeapon - 1].GetComponent<WeaponClass>().itemUsing = false;
                currentWeapon = 1;
                player.GetComponent<playerController>().weapons[currentWeapon - 1].GetComponent<WeaponClass>().itemUsing = true;
            } else
            {
                player.GetComponent<playerController>().weapons[currentWeapon - 1].GetComponent<WeaponClass>().itemUsing = false;
                currentWeapon += 1;
                player.GetComponent<playerController>().weapons[currentWeapon - 1].GetComponent<WeaponClass>().itemUsing = true;
            }
        }
        for (int i = 0; i < player.GetComponent<playerController>().weapons.Count; i++)
        {
            if (player.GetComponent<playerController>().weapons[i].GetComponent<WeaponClass>().itemUsing == false)
            {
                player.GetComponent<playerController>().weapons[i].transform.position = new Vector2(1000, 1000);
            }
        }
    }
}
