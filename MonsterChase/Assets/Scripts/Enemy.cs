using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float speed;
    private Rigidbody2D body;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //speed = 20f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity = new Vector2(speed, body.velocity.y);
    }
} //class
