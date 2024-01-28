using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = (3 - gameManager.drama).ToString() ;
    }
}
