using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : IEnemy
{
    [SerializeField] int mvtspeed;
    [SerializeField] int currentdirection = 1;
    public Rigidbody2D  rb;
    //public PlayerHealth playerHealth;
    LayerMask projectileLayer = 1;

    void Awake()
    {
        enemySprite = GetComponent<SpriteRenderer>();    
    }
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(currentdirection * mvtspeed * Time.deltaTime, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Change with layerMask
        if(collision.gameObject.tag == "ground")
        {
            currentdirection = -currentdirection;
        }

        if(collision.gameObject.layer == (projectileLayer << 2 | projectileLayer << 1))
        {
            SetDamage();
        }

        if(collision.gameObject.layer == projectileLayer << 3)
        {
            StartCoroutine(EnemyFlash());
            health -= Bullet.damage;
            print(health);
        }
    }
}
