using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class spikeScript : MonoBehaviour
{
    public float spikeSpeed = 0.05f;
    public List<Transform> spikePrefab;
    public Transform holder;
    public GameObject guy;
    ChatManager chatManager;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> spikes = guy.GetComponent<guyScript>().spikes;
        if (spikes.IndexOf(this.gameObject) == 1 && (this.transform.position.x - spikes[0].transform.position.x) <= 12)
        {
            this.transform.position = new Vector2(
                    this.transform.position.x + 10,
                    this.transform.position.y
                );
        }
    }
    void FixedUpdate()
    {
        if (this.transform.position.x <= (-28 - this.GetComponent<PolygonCollider2D>().bounds.size.x))
        {
            chatManager = GameObject.FindObjectOfType<ChatManager>();
            chatManager.viewerCount += 100;
            newSpike();
        }
        moveSpike();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void newSpike()
    {
        Transform prefab = spikePrefab[UnityEngine.Random.Range(0, spikePrefab.Count)];
        Transform newSpike = Instantiate(prefab, new Vector3(34f + UnityEngine.Random.Range(0, 12), this.transform.position.y, 0f), new Quaternion(0f, 0f, 0f, 0f), holder);
        newSpike.GetComponent<spikeScript>().spikePrefab = this.spikePrefab;
        newSpike.GetComponent<spikeScript>().spikeSpeed = this.spikeSpeed;
        newSpike.GetComponent<spikeScript>().holder = this.holder;
        newSpike.GetComponent<spikeScript>().guy = this.guy;
        newSpike.gameObject.transform.localScale = this.transform.localScale;
        guy.GetComponent<guyScript>().spikes.Add(newSpike.gameObject);
        guy.GetComponent<guyScript>().spikes.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
    void moveSpike()
    {
        this.transform.position = new Vector2(
                this.transform.position.x - spikeSpeed,
                this.transform.position.y
            );
    }
}
