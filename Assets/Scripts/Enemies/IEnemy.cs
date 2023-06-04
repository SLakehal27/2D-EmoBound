using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : MonoBehaviour
{
    public int health = 0;
    public int damage = 0;
    public PlayerHealth playerHealth;
    public SpriteRenderer enemySprite;
    public IEnumerator EnemyFlash()
    {
       enemySprite.color = new Color(1, 0, 0, 0.5f);
       yield return new WaitForSeconds(0.15f);
       enemySprite.color = Color.white;
       yield return new WaitForSeconds(0.15f);
    }

    protected virtual void SetDamage()
    {
        StartCoroutine(playerHealth.StartInvulnerability());
        playerHealth.TakeDamage(damage);
    }


}
