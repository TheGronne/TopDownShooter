using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer weaponUI;

    public List<Sprite> weaponSprites = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        weaponUI.sprite = weaponSprites[player.GetComponent<playerController>().itemID];
        weaponUI.color = new Color(1f,1f,1f,1f);
    }
}
