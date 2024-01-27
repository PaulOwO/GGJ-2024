using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class spikeScript : MonoBehaviour
{
    public float spikeSpeed = 0.05f;
    public Transform spikePrefab;
    public Transform holder;
    // Start is called before the first frame update
    void Start()
    {

    }
    void FixedUpdate()
    {
        if (this.transform.position.x <= -28)
        {
            Transform newSpike = Instantiate(this.spikePrefab, new Vector3(34f + Random.Range(0, 20), this.transform.position.y, 0f), new Quaternion(0f,0f,0f,0f), holder);
            newSpike.GetComponent<spikeScript>().spikePrefab = this.spikePrefab;
            newSpike.GetComponent<spikeScript>().holder = this.holder;
            if(Random.Range(0, 2) == 1)
            {
                Transform newSpike2 = Instantiate(this.spikePrefab, new Vector3(34f + Random.Range(0, 25), this.transform.position.y, 0f), new Quaternion(0f, 0f, 0f, 0f), holder);
                newSpike2.GetComponent<spikeScript>().spikePrefab = this.spikePrefab;
                newSpike2.GetComponent<spikeScript>().holder = this.holder;
            }
            Destroy(this.gameObject);
        }
        moveSpike();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void moveSpike()
    {
        this.transform.position = new Vector2(
                this.transform.position.x - spikeSpeed,
                this.transform.position.y
            );
    }
}
