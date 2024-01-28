using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public int jumpVelocity = 15;
    public List<GameObject> Pipes;
    ChatManager chatManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidBody.velocity = new Vector2(0, jumpVelocity);
        }
        transform.rotation = Quaternion.Euler(0, 0, rigidBody.velocity.y);
    }

    private void OnRestart()
    {
        transform.position = Vector2.zero;
        foreach (var pipe in Pipes)
        {
            pipe.SendMessage("StartReset");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = Vector2.zero;
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        rigidBody.velocity = new Vector2(0, 0);
        chatManager = GameObject.FindObjectOfType<ChatManager>();
        if (chatManager.viewerCount > 50)
        {
            chatManager.viewerCount -= 50;
        }
        else
        {
            chatManager.viewerCount = 1;
        }
        OnRestart();
    }

}
