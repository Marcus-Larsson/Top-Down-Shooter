using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] int playerHealth = 10;
    [SerializeField] float invincilityTime = 2f;
    bool invincible = false;

    void Disableinvincility()
    {
        invincible = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(invincible == true)
            {
                return;
            }
            if (playerHealth > 0)
            {
                playerHealth--;
                invincible = true;
                Invoke("Disableinvincility", invincilityTime);
                Debug.Log("player Health:" + playerHealth);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
