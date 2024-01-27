using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class pipeScript : MonoBehaviour
{
    public float x = 24;
    private float y = 5;
    public float pipeSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        StartReset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.transform.position.x <= -28)
        {
            resetPipe() ;
        }
        movePipe();
    }

    void resetPipe()
    {
        y = Random.Range(-2, 15);
        this.transform.position = new Vector2(26, y);
    }
    void movePipe()
    {
        this.transform.position = new Vector2(
                this.transform.position.x - pipeSpeed,
                this.transform.position.y
            );
    }

    void StartReset()
    {
        y = Random.Range(-2, 15);
        this.transform.position = new Vector2(x, y);
    }
}
