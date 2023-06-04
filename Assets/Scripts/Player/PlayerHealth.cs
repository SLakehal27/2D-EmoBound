using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth;
    [SerializeField] int flashFrames;
    [SerializeField] SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
    }
    public IEnumerator StartInvulnerability()
    {
        //ignores collision
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < flashFrames; i++)
        {
            playerSprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.15f);
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(0.15f);
        }

        Physics2D.IgnoreLayerCollision(6, 7, false);
        yield return new WaitForSeconds(0.1f);

    } 
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
