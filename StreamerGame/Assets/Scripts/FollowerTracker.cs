using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowerTracker : MonoBehaviour
{
    // Start is called before the first frame update
    ChatManager chatManager;
    TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        chatManager = GameObject.FindObjectOfType<ChatManager>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = chatManager.viewerCount.ToString();
    }
}
