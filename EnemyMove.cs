using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private SpriteRenderer sr;

    public float speed;
    public float bounds;

    private Vector3 initial;
    private Vector3 compareInitial;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        initial = transform.position;
        compareInitial = initial;
    }

    void Update()
    {
        move();
    }

    void move()
    {
        Vector3 location = transform.position;
        compareInitial.x += bounds;
        if (location.x >= compareInitial.x)
        {
            flip();
        }
        compareInitial = initial;
        compareInitial.x -= bounds;
        if (location.x <= compareInitial.x)
        {
            flip();
        }
        compareInitial = initial;
        if (transform.localScale.x > 0)
        {
            location.x -= speed * Time.deltaTime;
        }
        if (transform.localScale.x < 0)
        {
            location.x += speed * Time.deltaTime;
        }
        transform.position = location;
        
    }

    void flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
