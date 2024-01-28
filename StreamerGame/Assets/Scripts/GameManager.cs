using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject miniGameManager;
    public GameObject chatManager;
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
            miniGameManager.GetComponent<MiniGameManager>().SendMessage("StopAllGames");
            chatManager.GetComponent<ChatManager>().SendMessage("StopMsgs");
            gameOverUI.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.Space))
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
                chatManager.GetComponent<ChatManager>().viewerCount = (int)Math.Round((float)chatManager.GetComponent<ChatManager>().viewerCount * 0.9f);
                drama += 1;
            }
        }
    }
}
