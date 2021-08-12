using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float destroyTimer;
    private void Update()
    {
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
        destroyTimer -= Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Player") || collision.gameObject.tag.Contains("Item"))
        {
            
        } else if (collision.gameObject.tag.Contains("Enemy"))
        {
            if (this.gameObject.GetComponent<DamageController>().element == "water" && collision.gameObject.GetComponent<EnemyScript>().element == "fire")
            {
                collision.gameObject.GetComponent<HealthController>().hp -= this.gameObject.GetComponent<DamageController>().damage * 2;
            } else if (this.gameObject.GetComponent<DamageController>().element == "fire" && collision.gameObject.GetComponent<EnemyScript>().element == "electric") 
            {
                collision.gameObject.GetComponent<HealthController>().hp -= this.gameObject.GetComponent<DamageController>().damage * 2;
            } else if (this.gameObject.GetComponent<DamageController>().element == "electric" && collision.gameObject.GetComponent<EnemyScript>().element == "water")
            {
                collision.gameObject.GetComponent<HealthController>().hp -= this.gameObject.GetComponent<DamageController>().damage * 2;
            } else if (this.gameObject.GetComponent<DamageController>().element == "void" && collision.gameObject.GetComponent<EnemyScript>().element == "void")
            {
                collision.gameObject.GetComponent<HealthController>().hp -= this.gameObject.GetComponent<DamageController>().damage * 2;
            }
            else
            {
                collision.gameObject.GetComponent<HealthController>().hp -= this.gameObject.GetComponent<DamageController>().damage;
            }
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
