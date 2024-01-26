using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodScript : MonoBehaviour
{
    public BoxCollider2D area;

    private void Start()
    {
        NewPos();
    }

    private void NewPos()
    {
        Bounds bounds = this.area.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewPos();
    }
}
