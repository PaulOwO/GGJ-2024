using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Array array;
    int numberOfBan = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            numberOfBan = 0;
            array = FindObjectsOfType<banMessageScript>();
            foreach (banMessageScript script in array)
            {
                if (script.isBanned == false)
                {
                    script.Ban();
                    numberOfBan++;
                }
            }
            if (numberOfBan == 0)
            {
                print("lose health");
            }
        }
    }
}
