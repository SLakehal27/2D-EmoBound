using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        float direction = PlayerScript.isRight ? 1f : -1f;
        rb.velocity = (transform.right * direction) * moveSpeed;
    }

    bool isColliding(Collision2D col, string layer)
    {
        return col.gameObject.tag == layer;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (isColliding(col,"walls") || isColliding(col,"ground") || isColliding(col,"Teleporter"))
        {
            Destroy(gameObject);
        }
    }
}
