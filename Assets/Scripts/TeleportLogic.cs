using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLogic : MonoBehaviour
{
    private GameObject currentTeleporter;
    float offset = 1.5f;
    // Update is called once per frame
    void Update()
    {
        if (currentTeleporter != null)
        {
            Vector3 pos = currentTeleporter.GetComponent<Teleporter>().getDestination().position;
            if (PlayerScript.isRight) {
                transform.position = new Vector3(pos.x + offset, pos.y, pos.z);
            }
            else
            {
                transform.position = new Vector3(pos.x - offset, pos.y, pos.z);
            }
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Teleporter")
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Teleporter")
        {
            currentTeleporter = null;
        }
    }
}
