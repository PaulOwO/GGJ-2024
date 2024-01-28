using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using static GameManager;

public class ChatManager : MonoBehaviour
{
    public GameObject MessagePrefab;
    public GameObject QTEPrefab;
    public GameObject banPrefab;
    public GameObject changeGamePrefab;

    public MiniGameManager miniGameManager;

    public int followers = 1;

    public Collider2D area;

    private List<GameObject> messages = new List<GameObject>();
    private List<string> qteMessages = new List<string>();

    [SerializeField] MessageGenerator messageGenerator;

    private GameManager gameManager;

    private List<string> gameName = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameName.Add("Jumping Guy");
        gameName.Add("Fliyng Bird");
        gameName.Add("Long Serpent");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewMessage();
            UpdateChat();
        }


        foreach (GameObject message in messages.ToList())
        {
            if (message.tag == "QTE")
            {
                if (message.GetComponent<QTEScript>().isDone)
                {

                    TextMeshProUGUI text = message.GetComponent<TextMeshProUGUI>();
                    text.outlineWidth = 0.2f;
                    text.outlineColor = Color.green;
                }
            }

        }
    }

    float tt = 0.0f;
    private void CreateChat()
    {
        tt += Time.deltaTime;
        if (tt > 1.0f)
        {
            tt = 0.0f;
            ProbabilityOfMessage();
        }
    }

    private void ProbabilityOfMessage()
    {


        throw new NotImplementedException();
    }

    private void UpdateChat()
    {
        float currentheight = 0;
        if (messages.Count > 0)
        {
            int i = 0;
            foreach (GameObject message in messages.ToList())
            {

                /* RectTransform transform = message.GetComponent<RectTransform>();
                 transform.anchorMin = Vector2.zero;
                 transform.anchorMax = Vector2.right;
                  currentheight += transform.rect.height;
                  if (message == messages[0])
                  {
                     currentheight -= transform.rect.height/2; 
                  }
                  transform.anchoredPosition = new Vector2(0, currentheight);
                 print(transform.rect.height);*/

                if (message != messages[0])
                {
                    RectTransform transform = message.GetComponent<RectTransform>();
                    currentheight = transform.anchoredPosition.y;
                    transform.anchoredPosition = new Vector2(0, currentheight + 10 + messages[0].GetComponent<TextMeshProUGUI>().preferredHeight);
                }
                else
                {
                    message.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (float)message.GetComponent<TextMeshProUGUI>().preferredHeight / 2);
                }

                if (!area.bounds.Contains(message.transform.position)) //destruction when out of range
                {
                    if (message.tag == "QTE")
                    {
                        // missed a chat : red

                        if (message.GetComponent<QTEScript>().isDone == false)
                        {
                            gameManager.drama += 1;
                            print("missed a qte");
                        }

                        GameObject tmp = message;
                        messages.RemoveAt(i);
                        Destroy(tmp);
                        return;
                        
                    }
                    else if (message.tag == "Ban")
                    {
                        if (message.GetComponent<banMessageScript>().isBanned == false)
                        {
                            gameManager.drama += 1;
                            print("missed a ban");
                        }

                        GameObject tmp = message;
                        messages.RemoveAt(i);
                        Destroy(tmp);
                        return;
                    }
                    else if (message.tag == "Change")
                    {
                        if (miniGameManager.currentGame == message.GetComponent<ChangeMessageScript>().game) //l'objectif nest pas accompli
                        {
                            GameObject tmp = message;
                            messages.RemoveAt(i);
                            Destroy(tmp);
                            return;
                        }

                        gameManager.drama += 1;
                        print("didn't change the game");

                       
                    }
                    else
                    {
                        GameObject tmp = message;
                        messages.Remove(message);
                        Destroy(tmp);
                    }
                }
                i++;
            }
        }
    }
    GameObject tmp;
    private void NewMessage()
    {
        int rand = Random.Range(0, 10);
        if (rand < 7 )
        {

            tmp = null;
            tmp = Instantiate(MessagePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            tmp.transform.SetParent(transform, false);
            tmp.transform.localScale = new Vector3(1, 1, 1);

            TextMeshProUGUI UIText = tmp.GetComponent<TextMeshProUGUI>();
            string username = messageGenerator.CreateUsername();
            UIText.SetText("<color=" + Randomcolor() + ">"
                + username.Replace("\n", "").Replace("\r", "")
                + "</color>" + ": " + messageGenerator.takeFillerMessage());

            messages.Insert(0, tmp);

        }

        if(rand == 7)
        {
            tmp = null;
            tmp = Instantiate(QTEPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            tmp.transform.SetParent(transform, false);
            tmp.transform.localScale = new Vector3(1, 1, 1);

            int rando = Random.Range(0, qteMessages.Count);

            TextMeshProUGUI UIText = tmp.GetComponent<TextMeshProUGUI>();
            QTEScript qTEScript = tmp.GetComponent<QTEScript>();
            string qteInputs = messageGenerator.CreateQTE(qTEScript);
            string username = messageGenerator.CreateUsername();
            UIText.SetText("<color=" + Randomcolor() + ">"
                + username.Replace("\n", "").Replace("\r", "") + "</color>" 
                + ": " + messageGenerator.takeQTEMessage().Replace("\n", "").Replace("\r", "")+ " " + String.Join(" ", qteInputs.ToUpper().ToList()));

            messages.Insert(0, tmp);
        }

        if(rand == 8) 
        {
            tmp = null;
            tmp = Instantiate(banPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            tmp.transform.SetParent(transform, false);
            tmp.transform.localScale = new Vector3(1, 1, 1);

            TextMeshProUGUI UIText = tmp.GetComponent<TextMeshProUGUI>();
            string username = messageGenerator.CreateUsername();
            UIText.SetText("<color=" + Randomcolor() + ">"
                + username.Replace("\n", "").Replace("\r", "") + "</color>" 
                + ": " + messageGenerator.takeBanMessage());

            messages.Insert(0, tmp);
        }

        if (rand == 9)
        {
            tmp = null;
            tmp = Instantiate(changeGamePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            tmp.transform.SetParent(transform, false);
            tmp.transform.localScale = new Vector3(1, 1, 1);

            int randomi = Random.Range(0, 3); //add le fait de ne pas pouvoir tomber sur le jeux actuelle  // serpent, flapy bird, mario
            int v;
            if (miniGameManager.currentGame == gameName[0])
            {
                v = 0;
            }
            if (miniGameManager.currentGame == gameName[1])
            {
                v = 1;
            }
            else
            {
                v = 2;
            }
            while (randomi == v) 
            {
                randomi = Random.Range(0, 3);
            }


            TextMeshProUGUI UIText = tmp.GetComponent<TextMeshProUGUI>();
            string username = messageGenerator.CreateUsername();
            UIText.SetText("<color=" + Randomcolor() + ">"
                + username.Replace("\n", "").Replace("\r", "") + "</color>"
                + ": " + messageGenerator.takeChangeMessage().Replace("\n", "").Replace("\r", "")+ " " + gameName[randomi]) ;

            tmp.GetComponent<ChangeMessageScript>().game = gameName[randomi];
            messages.Insert(0, tmp);
        }
    }











































    private string Randomcolor()
    {
        string color = null;
        int rand = Random.Range(0, 6);
        if (rand == 0)
        {
            color = "purple";
        }
        if (rand == 1)
        {
            color = "yellow";
        }
        if (rand == 2)
        {
            color = "red";
        }
        if (rand == 3)
        {
            color = "green";
        }
        if (rand == 4)
        {
            color = "orange";
        }
        if (rand == 5)
        {
            color = "blue";
        }

        return color;
    }
}
