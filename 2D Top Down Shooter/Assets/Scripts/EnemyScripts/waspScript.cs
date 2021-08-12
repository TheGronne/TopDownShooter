using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waspScript : EnemyScript
{
    public Animator anim;
    void Start()
    {
        player = GameObject.Find("Player");
        speed += GameObject.Find("Controller").GetComponent<LVLControler>().lvlCounter;
        element = "electric";
        anim = player.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthController>().hp -= gameObject.GetComponent<DamageController>().damage;
            anim.Play("Hurt");
        }
    }
    private void Update()
    {
        if (player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else if (player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 target = player.transform.position;
        target.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
