using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField] float health = 5;

    void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Projectile p = collision.gameObject.GetComponent<Projectile>();
            //takeDamage(p.getDamage());
        }
    }
}
