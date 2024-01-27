using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChatManager : MonoBehaviour
{
    public GameObject MessagePrefab;

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
    }

    private void UpdateChat()
    {
        float currentheight = 0;
        if (messages.Count > 0)
        {
            foreach (GameObject message in messages)
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
            }
        }
        if (messages.Count > 10)
        {
            GameObject tmp = messages[10];
            messages.RemoveAt(10);
            Destroy(tmp);
        }
    }
    GameObject tmp;
    private void NewMessage()
    {
        tmp = null;
        tmp = Instantiate(MessagePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        TextMeshProUGUI UIText = tmp.GetComponent<TextMeshProUGUI>();
        string username = messageGenerator.CreateUsername();
;        UIText.SetText("<color=" + Randomcolor() + ">" 
    + username.Replace("\n", "").Replace("\r", "") 
    + "</color>"+ ": " + messageGenerator.takeFillerMessage());

        tmp.transform.SetParent(transform, false);
        tmp.transform.localScale = new Vector3(1, 1, 1);
        messages.Insert(0, tmp);

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
