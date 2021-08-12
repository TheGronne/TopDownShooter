using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public GameObject player;
    public Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bar = transform.Find("bar");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<HealthController>().hp == 0)
        {
            bar.localScale = new Vector3(0f, 1f);
        }
        else if (player.GetComponent<HealthController>().hp > 0 && player.GetComponent<HealthController>().hp <= 10)
        {
            bar.localScale = new Vector3(.1f, 1f);
        } 
        else if (player.GetComponent<HealthController>().hp > 10 && player.GetComponent<HealthController>().hp <= 20)
        {
            bar.localScale = new Vector3(.2f, 1f);
        }
        else if (player.GetComponent<HealthController>().hp > 20 && player.GetComponent<HealthController>().hp <= 30)
        {
            bar.localScale = new Vector3(.3f, 1f);
        }
        else if (player.GetComponent<HealthController>().hp > 30 && player.GetComponent<HealthController>().hp <= 40)
        {
            bar.localScale = new Vector3(.4f, 1f);
        }
        else if (player.GetComponent<HealthController>().hp > 40 && player.GetComponent<HealthController>().hp <= 50)
        {
            bar.localScale = new Vector3(.5f, 1f);
        }
        else if (player.GetComponent<HealthController>().hp > 50 && player.GetComponent<HealthController>().hp <= 60)
        {
            bar.localScale = new Vector3(.6f, 1f);
        }
        else if (player.GetComponent<HealthController>().hp > 60 && player.GetComponent<HealthController>().hp <= 70)
        {
            bar.localScale = new Vector3(.7f, 1f);
        }
        else if (player.GetComponent<HealthController>().hp > 70 && player.GetComponent<HealthController>().hp <= 80)
        {
            bar.localScale = new Vector3(.8f, 1f);
        }
        else if (player.GetComponent<HealthController>().hp > 80 && player.GetComponent<HealthController>().hp <= 90)
        {
            bar.localScale = new Vector3(.9f, 1f);
        }
        else
        {
            bar.localScale = new Vector3(1f, 1f);
        }
    }
}