using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class banMessageScript : MonoBehaviour
{
    public bool isBanned = false;
    public void Ban()
    {
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
