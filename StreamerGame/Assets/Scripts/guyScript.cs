using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guyScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public int jumpVelocity = 15;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            rigidbody.velocity = new Vector2(0, jumpVelocity);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            grounded = true;
        }
    }
}
