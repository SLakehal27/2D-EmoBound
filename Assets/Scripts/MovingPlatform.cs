using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public int moveSpeed = 5;
    public Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = posB.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posB.position) < 1f)
            targetPos = posA.position;
        if (Vector2.Distance(transform.position, posA.position) < 1f)
            targetPos = posB.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision !=null)
        {
             collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision != null)
        {
            collision.transform.SetParent(null);
        }
    }
}
