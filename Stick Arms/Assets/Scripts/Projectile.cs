using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] float bulletLifeTime;

    Rigidbody2D rb;
    float speed;
    public bool isLeft = false;

    private void Start()
    {
        speed = gun.Speed; //Taking speed value from gun prefab

        rb = GetComponent<Rigidbody2D>();

        if (isLeft) //Checking if the gun is facing the left or right side
            rb.velocity = -(transform.right * speed);
        else
            rb.velocity = transform.right * speed;

        Invoke("destroy", bulletLifeTime);
    }

    void destroy()
    {
        Destroy(gameObject, 0.5f);
    }
}
