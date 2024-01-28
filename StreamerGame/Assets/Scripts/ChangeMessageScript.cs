using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMessageScript : MonoBehaviour
{
    public string game;
    public MiniGameManager miniGameManager;
    public bool isDone = false;
    public bool pointsAwarded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (game == miniGameManager.currentGame)
        { 
            isDone = true;
        }
    }
}
