using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderScript : EnemyScript
{
    public Animator anim;
    void Start()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
        speed += GameObject.Find("Controller").GetComponent<LVLControler>().lvlCounter;
        gameObject.GetComponent<DamageController>().damage += GameObject.Find("Controller").GetComponent<LVLControler>().lvlCounter * 2;
        int randomNumber = Random.Range(1, 5);
        int randomN = randomNumber;
        switch (randomN)
        {
            case 1:
                element = "fire";
                break;
            case 2:
                element = "water";
                break;
            case 3:
                element = "electric";
                break;
            case 4:
                element = "void";
                break;
            default:
                element = "void";
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthController>().hp -= gameObject.GetComponent<DamageController>().damage;
            anim.Play("Hurt");
        }
    }
    void FixedUpdate()
    {
        Vector3 target = player.transform.position;
        target.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        Vector3 moveDirection = gameObject.transform.position - player.transform.position;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Rotate(0f, 0f, -90f);
        }
    }
}