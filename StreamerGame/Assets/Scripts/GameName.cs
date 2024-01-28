using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameName : MonoBehaviour
{
    MiniGameManager miniGameManager;
    TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
       miniGameManager  = GameObject.FindObjectOfType<MiniGameManager>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = miniGameManager.currentGame;
    }
}
