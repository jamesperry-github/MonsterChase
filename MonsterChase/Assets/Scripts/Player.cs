using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementForce = 10.0f;
    public float jumpForce = 11.0f;
    //
    public float movementX;
    private SpriteRenderer sr;
    private Rigidbody2D body;
    private Animator anim;
    private string WALK_ANIMATION = "isWalking";
    private string JUMP_ANIMATION = "isJumping";
    private bool isGrounded;
    private string GROUND = "Ground";
    private string ENEMY = "Enemy";
    // Awake
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"The body is {body}");
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        Jump();
    }

    //void FixedUpdate()
    //{
    //    Debug.Log("FIXED UPDATE");
    //    JumpPlayer();
    //}
    void PlayerMoveKeyboard()
    {
        // WASD
        // Time.deltaTime = Time between frames
        movementX = Input.GetAxisRaw("Horizontal"); // gets key press 'A'(-1) or 'D'(1)
        AnimatePlayer();
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * movementForce;
    }
    void AnimatePlayer()
    {
        if(movementX == -1) // key press 'A'(-1)
        {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if(movementX == 1) // key press 'D'(1)
        {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        } else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // PC defaults to SPACE_BAR
        {
            isGrounded = false;
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool(JUMP_ANIMATION, true);
        }
        //Debug.Log(Input.GetButtonDown("Jump"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // detect collision between game objects
        if(collision.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
            anim.SetBool(JUMP_ANIMATION, false);
        }
        if (collision.gameObject.CompareTag(ENEMY))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 
        if (collision.gameObject.CompareTag(ENEMY))
        {
            Destroy(gameObject);
        }
    }
} //class
