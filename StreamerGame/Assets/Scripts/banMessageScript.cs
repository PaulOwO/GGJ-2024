using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class banMessageScript : MonoBehaviour
{
    public bool isBanned = false;
    ChatManager chatManager;
    public void Ban()
    {
        chatManager = GameObject.FindObjectOfType<ChatManager>();
        chatManager.viewerCount = (int)Math.Round((float)chatManager.viewerCount * 1.1f);
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = "<i> This user was banned from your channel </i>";
        text.fontSize = 18;
        text.color = Color.red;
        isBanned = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
