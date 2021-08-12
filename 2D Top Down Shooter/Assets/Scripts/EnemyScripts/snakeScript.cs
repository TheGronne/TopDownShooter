using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class snakeScript : EnemyScript
{
    public Animator anim;
    public Sprite[] sprites = new Sprite[4];
    public GameObject bulletPrefab;
    float coolDown = 1.5f;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
        speed = 0;
        int randomNumber = Random.Range(1, 8);
        int randomN = randomNumber;
        switch (randomN)
        {
            case 1:
                element = "fire";
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case 2:
                element = "water";
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case 3:
                element = "electric";
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
            case 4:
                element = "Neutral";
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
                break;
            default:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (coolDown >= 0)
        {
            coolDown -= Time.deltaTime;
        }
        if (coolDown <= 0)
        {
            shoot();
        }
    }

    void shoot()
    {
        float bulletSpeed = 5f;
        GameObject target = GameObject.Find("Player");
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        coolDown = 1.5f;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 direction = (target.transform.position - bullet.transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(direction.x, direction.y);
        bullet.GetComponent<DamageController>().element = this.gameObject.GetComponent<DamageController>().element;
    }
}
