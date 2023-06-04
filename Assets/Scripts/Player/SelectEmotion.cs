using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEmotion : MonoBehaviour
{
    Emotion[] spectrum = { Emotion.NEUTRAL, Emotion.ANGRY, Emotion.SAD, Emotion.HAPPY };
    int currentEmotion = 0;
    [SerializeField] PlayerScript player;
    bool isSelecting = false;
    int keyCount = 0;

    //Visual elements:
    public GameObject selector;

    //void Start()
    //{
        
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && keyCount == 0)
        {
            isSelecting = true;
            player.canJump = false;
            player.canMove = false;
            player.rb.gravityScale = 0;
            player.rb.velocity = new Vector2(0,0);
            keyCount++;
            selector.SetActive(true);
        }

        if (isSelecting)
        {
            if (currentEmotion < 0) currentEmotion = spectrum.Length - 1;
            else if (currentEmotion > 3) currentEmotion = 0;

            print(spectrum[currentEmotion]);

            if (Input.GetKeyDown(KeyCode.C) && keyCount == 2)
            {
                EnablePlayerMovement();
                //logic to change the player's appearance;
                player.SetEmotion(spectrum[currentEmotion]);
            }

            //Cancels Selection;
            if (Input.GetKeyDown(KeyCode.V))
            {
                EnablePlayerMovement();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                selector.transform.Rotate(new Vector3(0, 0, 90));
                currentEmotion++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selector.transform.Rotate(new Vector3(0, 0, -90));
                currentEmotion--;
            }

            if (Input.GetKeyDown(KeyCode.C) && keyCount == 1)
            {
                keyCount++;
            }
        }
    }

    void EnablePlayerMovement()
    {
        isSelecting = false;
        player.canMove = true;
        player.canJump = true;
        player.rb.gravityScale = 3;
        keyCount = 0;
        selector.SetActive(false);
    }
}
