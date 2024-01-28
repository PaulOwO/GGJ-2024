using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public List<GameObject> miniGames;
    public string currentGame = "";
    public List<AudioClip> audioClipList;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var game in miniGames)
        {
            game.gameObject.SetActive(false);
        }
        miniGames[0].gameObject.SetActive(true);
        currentGame = miniGames[0].name;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClipList[0];
        audioSource.Play();

    }

    void StopAllGames()
    {
        miniGames[0].gameObject.SetActive(false);
        miniGames[1].gameObject.SetActive(false);
        miniGames[2].gameObject.SetActive(false);
    }

    // Update is called once per frame

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentGame != miniGames[0].name)
        {
            miniGames[0].gameObject.SetActive(true);
            currentGame = miniGames[0].name;
            miniGames[1].gameObject.SetActive(false);
            miniGames[2].gameObject.SetActive(false);
            miniGames[0].transform.GetChild(0).GetComponent<snakeScript>().SendMessage("OnRestart");

            audioSource.clip = audioClipList[0];
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentGame != miniGames[1].name)
        {
            miniGames[0].gameObject.SetActive(false);
            miniGames[1].gameObject.SetActive(true);
            currentGame = miniGames[1].name;
            miniGames[2].gameObject.SetActive(false);

            miniGames[1].transform.GetChild(0).GetComponent<birdScript>().SendMessage("OnRestart");

            audioSource.clip = audioClipList[1];
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentGame != miniGames[2].name)
        {
            miniGames[0].gameObject.SetActive(false);
            miniGames[1].gameObject.SetActive(false);
            miniGames[2].gameObject.SetActive(true);
            currentGame = miniGames[2].name;

            miniGames[2].transform.Find("GuyRigidBody").GetChild(0).GetComponent<guyScript>().SendMessage("OnRestart");

            audioSource.clip = audioClipList[2];
            audioSource.Play();
        }
    }
}
