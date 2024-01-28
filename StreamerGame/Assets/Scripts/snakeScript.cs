using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeScript : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private Vector2 _lastDirection = Vector2.right;
    private List<Transform> _parts = new List<Transform>();
    public Transform bodyPrefab;
    public Transform holder;

    void Start()
    {
        _parts = new List<Transform>();
        _parts.Add(this.transform);
        StartCoroutine("Move");
    }

    private void OnRestart()
    {
        Clear();
        StopCoroutine("Move");
        _parts = new List<Transform>();
        _parts.Add(this.transform);
        StartCoroutine("Move");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _lastDirection != Vector2.down)
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && _lastDirection != Vector2.up)
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && _lastDirection != Vector2.right)
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && _lastDirection != Vector2.left)
        {
            _direction = Vector2.right;
        }
    }

    private IEnumerator Move()
    {
        for (; ; )
        {

            for (int i = _parts.Count - 1; i > 0; i--)
            {
                _parts[i].position = _parts[i - 1].position;
            }

            this.transform.position = new Vector2(
                Mathf.Round(this.transform.position.x) + _direction.x,
                Mathf.Round(this.transform.position.y) + _direction.y
            );
            _lastDirection = _direction;

            yield return new WaitForSeconds(.06f);
        }
    }

    private void Eat()
    {
        Transform part = Instantiate(this.bodyPrefab,holder);
        part.position = _parts[_parts.Count - 1].position;
        _parts.Add(part);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Eat();
        }
        else if ((collision.tag == "Tail" && collision.gameObject.transform != _parts[1]) || collision.tag == "Wall")
        {
            Clear();
        }
    }

    private void Clear()
    {
        if( _parts.Count > 0 )
        {
            for (int i = 1; i < _parts.Count; i++)
            {
                Destroy(_parts[i].gameObject);
            }
        }
        _parts.Clear();
        _parts.Add(this.transform);
        _direction = Vector2.right;
        this.transform.position = Vector2.zero;
    }
}
