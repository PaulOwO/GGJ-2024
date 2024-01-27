using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MessageGenerator : MonoBehaviour
{
    public TextAsset fileData;

    public TextAsset fillerMessageData;

    List<String> nameStarts = new List<String> { };
    List<String> nameEnds = new List<String> { };
    List<String> nameNumbers = new List<String> { };

    List<String> fillerMessage = new List<String> { };

    public String generatedName = null;


    void Start()
    {
        readNameCSV();
        readFillerMessageCSV();
        generatedName = CreateUsername();
    }

    void readFillerMessageCSV()
    {
        fillerMessage = fillerMessageData.text.Split("\n", StringSplitOptions.None).ToList<String>();
    }
    void readNameCSV()
    {
        List<String> rows = fileData.text.Split("\n", StringSplitOptions.None).ToList<String>();

        rows.RemoveAt(0);

        foreach (var item in rows)
        {
            string[] nameParts = item.Split(new string[] { "," }, StringSplitOptions.None);
            if (!string.IsNullOrEmpty(nameParts[0]))
            {
                nameStarts.Add(nameParts[0]);
            }
            if (!string.IsNullOrEmpty(nameParts[1]))
            {
                nameEnds.Add(nameParts[1]);
            }
            if (!string.IsNullOrEmpty(nameParts[2]))
            {
                nameNumbers.Add(nameParts[2]);
            }
        }
    }

    public string takeFillerMessage()
    {
        System.Random rnd = new System.Random();
        string rand = fillerMessage[rnd.Next(fillerMessage.Count - 1)];
        return rand;
    }

    public string CreateUsername()
    {
        System.Random rnd = new System.Random();
        if (rnd.Next(1000) <= 1)
        {
            return "SourisFeroce";
        }

        string randStart = nameStarts[rnd.Next(nameStarts.Count - 1)];
        string randEnd = nameEnds[rnd.Next(nameEnds.Count - 1)];

        if (rnd.Next(10) > 5)
        {
            randStart = randStart.FirstCharacterToUpper();
        }

        if (rnd.Next(10) > 5)
        {
            randEnd = randEnd.FirstCharacterToUpper();
        }

        string randNum = null;

        if (rnd.Next(10) > 3)
        {
            randNum = nameNumbers[rnd.Next(nameNumbers.Count - 1)];
        } else
        {
            randNum = "";
        }

        if (rnd.Next(10) > 5)
        {
            return randStart + "_" + randEnd + randNum;
        }
        else 
        {
            return randStart + randEnd + randNum;
        }
    }
}
