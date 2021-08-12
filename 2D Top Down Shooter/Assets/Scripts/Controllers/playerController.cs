using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed;
    public bool usingItem = false;
    public int itemID;
    public int coins;
    
    public GameObject bullet;
    public Rigidbody2D rb;

    public List<GameObject> weapons = new List<GameObject>();

    Vector2 movement;
    public Vector2 shootPoint;

    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseGame();
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 45);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 135);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 225);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 315);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
        Vector2 position = transform.position;
        position.x += Time.deltaTime * moveSpeed * horizontal;
        position.y += Time.deltaTime * moveSpeed * vertical;
        rb.MovePosition(position);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}