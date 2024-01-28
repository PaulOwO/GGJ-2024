using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class guyScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public int jumpVelocity = 15;
    private bool grounded = false;
    private Vector3 basePos;
    private Quaternion baseRotation;
    private Vector3 baseVelocity;
    public List<GameObject> spikes;
    private Vector3 lastVelocity;
    private bool played;
    ChatManager chatManager;

    // Start is called before the first frame update
    void Start()
    {
        basePos = this.transform.position;
        baseRotation = this.transform.rotation;
        baseVelocity = rigidbody.velocity;
        lastVelocity = rigidbody.velocity;
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y < -6.5f && transform.position.y > -7f) && rigidbody.velocity.y < 0 && !played)
        { 
            this.GetComponent<Animator>().Play("Guy_Jump_Down");
            played = true;
        }
        if (transform.position.y <= -7f && rigidbody.velocity.y < 0)
        {
            grounded = true;
            played = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            rigidbody.velocity = new Vector2(0, jumpVelocity);
            grounded = false;
            this.GetComponent<Animator>().Play("Guy_Jump");
        }
        lastVelocity = rigidbody.velocity;
    }

    private void OnRestart()
    {
        foreach (var spike in spikes.ToList())
        {
            spike.SendMessage("newSpike");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            chatManager = GameObject.FindObjectOfType<ChatManager>();
            if (chatManager.viewerCount > 5)
            {
                chatManager.viewerCount -= 5;
            }
            else
            {
                chatManager.viewerCount = 1;
            }
            this.transform.position = basePos;
            this.transform.rotation = baseRotation;
            rigidbody.velocity = new Vector3(0f, 0f, 0f);
            rigidbody.angularVelocity = 0f;
            this.GetComponent<Animator>().Play("Guy_Run");
            foreach (var spike in spikes.ToList())
            {
                spike.SendMessage("newSpike");
            }
        }
    }
}
