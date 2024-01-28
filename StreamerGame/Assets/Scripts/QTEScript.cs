using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEScript : MonoBehaviour
{
    public bool isDone = false;
    public bool pointsAwarded = false;
    public List<string> inputs = new List<string>();
    
    private bool Check1 = false;
    private bool Check2 = false;
    private bool Check3 = false;
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inputs[0]) && Check1 == false)
        {
            Check1 = true;
        }

        if (Input.GetKeyDown(inputs[1]) && Check2 == false)
        {
            Check2 = true;
        }

        if (Input.GetKeyDown(inputs[2]) && Check3 == false)
        {
            Check3 = true;
        }

        if (Check1 && Check2 && Check3 && isDone == false)
        {
            isDone = true;
        }
    }
}
