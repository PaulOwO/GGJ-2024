using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        gameOverUI = GameObject.Find("GameOver");
        gameOverUI.SetActive(false);
    }
    public int drama = 0;

    Array array;
    int numberOfBan = 0;
    // Update is called once per frame
    void Update()
    {
        if (drama > 2)
        {
            //game over
            gameOverUI.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            numberOfBan = 0;
            array = FindObjectsOfType<banMessageScript>();
            foreach (banMessageScript script in array)
            {
                if (script.isBanned == false)
                {
                    script.Ban();
                    numberOfBan++;
                }
            }
            if (numberOfBan == 0)
            {
                drama += 1;
                print("no one to ban");
            }
        }
    }
}
