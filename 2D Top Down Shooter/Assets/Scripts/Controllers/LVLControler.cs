using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LVLControler : MonoBehaviour
{
    public GameObject player;
    public GameObject forestLVL1;
    public GameObject forestLVL2;
    public GameObject forestLVL3;
    public GameObject desertLVL1;
    public GameObject desertLVL2;
    public GameObject desertLVL3;
    public GameObject snowLVL1;
    public GameObject snowLVL2;
    public GameObject snowLVL3;
    public GameObject shop;
    public List<GameObject> SpawnedEnemies = new List<GameObject>();
    public int lvlCounter = 1;
    public GameObject currentlvl;
    public GameObject currentlvltext;
    public int numberOfEnemies;
    public GameObject enemiesleft;
    public GameObject victorymenu;
    public GameObject currentShop;
    public GameObject ammoLeftText;
    public GameObject ammoLeftUI;
    public GameObject amountOfCoins;
    public int firstTimeCounter; //Bliver brugt for at stoppe nogle ting i update sådan at de ikke kører mens man er i gang med noget andet
    public bool newlvlrunning = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        firstTimeCounter = 1;
        player = GameObject.Find("Player");
        int randomLVL = Random.Range(1, 4);
        switch (randomLVL)
        {
            case 1:
                currentlvl = Instantiate(forestLVL1);
                break;
            case 2:
                currentlvl = Instantiate(forestLVL2);
                break;
            case 3:
                currentlvl = Instantiate(forestLVL3);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(firstTimeCounter);
        Debug.Log(SpawnedEnemies.Count);
        amountOfCoins.GetComponent<Text>().text = player.GetComponent<playerController>().coins.ToString();
        numberOfEnemies = SpawnedEnemies.Count;
        if (player.GetComponent<playerController>().weapons.Count == 0)
        {
            ammoLeftUI.SetActive(false);
            player.GetComponent<playerController>().usingItem = false;
        }
        if (SpawnedEnemies.Count == 0 && firstTimeCounter == 0 && newlvlrunning == false)
        {
            lvlCounter++;
            victoryMenu();
            firstTimeCounter = 1;
        }
        enemiesleft.GetComponent<Text>().text = ("Left: " + numberOfEnemies);
        if (lvlCounter < 5)
        {

        } else if (lvlCounter < 10)
        {
            Camera.main.backgroundColor = Color.yellow;
        } else if (lvlCounter < 15)
        {
            Camera.main.backgroundColor = Color.grey;
        }
        if (lvlCounter >= 5 && lvlCounter < 10)
        {
            GameObject.Find("ForestMusic").GetComponent<AudioSource>().mute = true;
            GameObject.Find("DesertMusic").GetComponent<AudioSource>().mute = false;
        }
    }

    public void newlvl()
    {
        newlvlrunning = true;
        currentlvl.SetActive(false);
        int randomLVL = Random.Range(1, 4);
        if (lvlCounter < 5)
        {
            switch (randomLVL)
            {
                case 1:
                    currentlvl = Instantiate(forestLVL1);
                    break;
                case 2:
                    currentlvl = Instantiate(forestLVL2);
                    break;
                case 3:
                    currentlvl = Instantiate(forestLVL3);
                    break;
                default:
                    break;
            }
        } else if (lvlCounter < 10)
        {
            switch (randomLVL)
            {
                case 1:
                    currentlvl = Instantiate(desertLVL1);
                    break;
                case 2:
                    currentlvl = Instantiate(desertLVL2);
                    break;
                case 3:
                    currentlvl = Instantiate(desertLVL3);
                    break;
                default:
                    break;
            }
        } else if (lvlCounter < 15)
        {
            switch (randomLVL)
            {
                case 1:
                    currentlvl = Instantiate(snowLVL1);
                    break;
                case 2:
                    currentlvl = Instantiate(snowLVL2);
                    break;
                case 3:
                    currentlvl = Instantiate(snowLVL3);
                    break;
                default:
                    break;
            }
        }
        player.transform.position = new Vector2(-1.5f, -0.8f);
        currentlvltext.GetComponent<Text>().text = ("Current lvl: " + lvlCounter);
        firstTimeCounter = 0;
    }

    public void victoryMenu()
    {
        Time.timeScale = 0;
        victorymenu.SetActive(true);
    }

    public void goToShop()
    {
        Time.timeScale = 1;
        victorymenu.SetActive(false);
        currentShop = Instantiate(shop);
        player.transform.position = new Vector2(-1.5f, -0.8f);
        currentlvl.SetActive(false);
    }

    public void NextLevel()
    {
        victorymenu.SetActive(false);
        newlvl();
        Time.timeScale = 1;
    }
    private void FixedUpdate()
    {
        ammoLeftText.GetComponent<Text>().text = player.GetComponent<playerController>().weapons[player.GetComponent<swapItems>().currentWeapon - 1].GetComponent<WeaponStats>().ammo.ToString();
    }

    public void retryGame()
    {
        SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene("InGame");
    }
}
