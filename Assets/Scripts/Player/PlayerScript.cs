using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    [SerializeField] float mvtspeed = 8f;
    [SerializeField] int jumpoffset = 14;
    int numberOfJumps = 0;
    public Animator anim;
    public GameObject cam;
    public Emotion actualEmotion = Emotion.NEUTRAL;

    //Booleans
    public static bool isRight { get; private set; }
    public bool canMove = true;
    public bool isGrounded = false;
    public bool canJump = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if ( ((isGrounded && canMove) || numberOfJumps < 2) && canJump)
            {
                //Jumping Logic;
                rb.velocity = new Vector2(transform.position.x, rb.velocity.y + jumpoffset);
                isGrounded = false;
                anim.SetBool("isJumping", true);
                numberOfJumps = numberOfJumps + 1;
            }
        }

        if (isGrounded || canMove)
        {
            anim.SetBool("isLanding", false);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(transform.position.x, rb.velocity.y * 0.5f);
        }

        if (rb.velocity.y < 0f && !isGrounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isLanding", true);
        }


        switch (horizontal)
        {
            case -1:
                if (canMove)
                {
                    anim.SetBool("canMove", true);
                    isRight = false;
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }
                break;
            case 1:
                if (canMove)
                {
                    anim.SetBool("canMove", true);
                    isRight = true;
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
                break;
            default:
                anim.SetBool("canMove", false);
                break;
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(horizontal * mvtspeed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
            numberOfJumps = 0;
        }
    }

    public void SetEmotion(Emotion otherEmotion)
    {
        actualEmotion = otherEmotion;
    }

    public void SetAngryParameters()
    {
        numberOfJumps = 1;
        mvtspeed = 6f;
        jumpoffset = 13;
    }
    public void SetNeutralParameters()
    {
        mvtspeed = 8f;
        jumpoffset = 14;
    }

    public void SetHappyParameters()
    {
        mvtspeed = 13f;
        jumpoffset = 16;
    }
}
