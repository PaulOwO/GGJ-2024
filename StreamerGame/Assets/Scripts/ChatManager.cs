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
        }
        UpdateChat();
    }

    private void UpdateChat()
    {
        float currentheight = 0;
        if (messages.Count > 0)
        {
            foreach (GameObject message in messages)
            {
                
                RectTransform transform = message.GetComponent<RectTransform>();
                transform.anchorMin = Vector2.zero;
                transform.anchorMax = Vector2.right;
                 currentheight += transform.rect.height;
                 if (message == messages[0])
                 {
                    currentheight -= transform.rect.height/2; 
                 }
                 transform.anchoredPosition = new Vector2(0, currentheight);
                print(transform.rect.height);


                /*RectTransform transform = message.GetComponent<RectTransform>();
                currentheight = transform.position.y ;
                transform.anchoredPosition = new Vector2(0, currentheight + messages[messages.Count - 1].GetComponent<RectTransform>().rect.height);*/
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
        int rand = Random.Range(0, 2);
        tmp = Instantiate(MessagePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        if (rand == 1)
        {
            TextMeshProUGUI arg = tmp.GetComponent<TextMeshProUGUI>();
            arg.SetText("arg ggggggggggggggggggggggggggggggggggg ggggggggggggggggggggggggggggggggggg gggggggggggggggggggggggggggg ggggggggg");
        }
        
        tmp.transform.SetParent(transform, false);
        tmp.transform.localScale = new Vector3(1, 1, 1);
        messages.Insert(0,tmp);
        
    }
}
