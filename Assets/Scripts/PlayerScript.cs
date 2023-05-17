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
    public static bool isRight = true;


    public class Player
    {
        int coinCount = 10;
        public bool canMove = true;
        public bool isGrounded = false;
        public void printCoins() {
            print(coinCount);
        }
    }

    Player main = new Player();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if(main.isGrounded == true && main.canMove == true || numberOfJumps < 2)
            {
                //Jumping Logic;
                rb.velocity = new Vector2(transform.position.x, rb.velocity.y + jumpoffset);
                main.isGrounded = false;
                anim.SetBool("isJumping", true);
                numberOfJumps++;
            }
        }

        if(main.isGrounded || main.canMove)
        {
            anim.SetBool("isLanding", false);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(transform.position.x, rb.velocity.y * 0.5f);
        }

        if(rb.velocity.y < 0f && !main.isGrounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isLanding", true);
        }


        switch (horizontal)
        {
            case -1:
                if (main.canMove)
                {
                    anim.SetBool("canMove", true);
                    isRight = false;
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }
                break;
            case 1:
                if (main.canMove)
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
        if (main.canMove == true)
        {
            rb.velocity = new Vector2(horizontal * mvtspeed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            main.isGrounded = true;
            numberOfJumps = 0;
        }
    }
}
