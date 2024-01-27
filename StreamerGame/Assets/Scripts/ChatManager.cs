using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChatManager : MonoBehaviour
{
    public GameObject MessagePrefab;
    public GameObject QTEPrefab;

    private List<GameObject> messages = new List<GameObject>();

    [SerializeField] MessageGenerator messageGenerator;

    // Start is called before the first frame update
    void Start()
    {

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
                    transform.anchoredPosition = new Vector2(0, currentheight + messages[0].GetComponent<TextMeshProUGUI>().preferredHeight);
                }
                else
                {
                    message.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (float)message.GetComponent<TextMeshProUGUI>().preferredHeight / 2);
                }

                if (i > 10) //destruction when to much
                {
                    if (message.tag == "QTE")
                    {
                        // missed a chat : red
                        //health loss

                        GameObject tmp = message;
                        messages.RemoveAt(i);
                        Destroy(tmp);
                    }
                    else
                    {
                        GameObject tmp = message;
                        messages.RemoveAt(i);
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
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {

            tmp = null;
            tmp = Instantiate(MessagePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            tmp.transform.SetParent(transform, false);
            tmp.transform.localScale = new Vector3(1, 1, 1);

            TextMeshProUGUI UIText = tmp.GetComponent<TextMeshProUGUI>();
            string username = messageGenerator.CreateUsername();
            ; UIText.SetText("<color=" + Randomcolor() + ">"
                + username.Replace("\n", "").Replace("\r", "")
                + "</color>" + ": " + messageGenerator.takeFillerMessage());

            messages.Insert(0, tmp);

        }
        if(rand == 1)
        {
            tmp = null;
            tmp = Instantiate(QTEPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            tmp.transform.SetParent(transform, false);
            tmp.transform.localScale = new Vector3(1, 1, 1);

            TextMeshProUGUI UIText = tmp.GetComponent<TextMeshProUGUI>();
            string username = messageGenerator.CreateUsername();
            ; UIText.SetText("<color=" + Randomcolor() + ">"
                + username.Replace("\n", "").Replace("\r", "")
                + "</color>" + ": " + "this is a q t e");

            messages.Insert(0, tmp);
        }
    }
































    private string Randomcolor()
    {
        string color = null;
        int rand = Random.Range(0, 7);
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
            color = "white";
        }
        if (rand == 6)
        {
            color = "blue";
        }

        return color;
    }
}
