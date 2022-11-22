using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float speed;
    private Rigidbody2D body;
    private string WALL = "Wall";
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // detect collision between game objects
        if (collision.gameObject.CompareTag(WALL))
        {
            //isGrounded = true;
            //anim.SetBool(JUMP_ANIMATION, false);
            Debug.Log("DESPAWN THE MONSTER");
        }
    }
} //class
