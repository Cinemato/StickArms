using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f; public float MovementSpeed { set { movementSpeed = value; } }
    [SerializeField] RectTransform joystickHandleShooting;
    [SerializeField] Joystick joystick;
    Animator anime;
    float originalSpeed; public float OriginalSpeed { get { return originalSpeed; } }

    Rigidbody2D rb;
    Vector2 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        originalSpeed = movementSpeed;
    }

    void Update()
    {
        //movementInput.x = Input.GetAxisRaw("Horizontal"); //Keyboard input (for pc testing)
        //movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput.x = joystick.Horizontal; //Getting input from joystick
        movementInput.y = joystick.Vertical;

        movementInput = movementInput.normalized;

        anime.SetFloat("Horizontal", movementInput.x);
        anime.SetFloat("Vertical", movementInput.y);

        anime.SetFloat("Speed", movementInput.sqrMagnitude);

        if(joystickHandleShooting.anchoredPosition.x == 0 && joystickHandleShooting.anchoredPosition.y == 0) //Checking first if the player is shooting or not
        {
            if (movementInput.x > 0) //Checking if the player is facing left or right, and changing the scal accordingly
                transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
            else if (movementInput.x < 0)
                transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
        }
        
    }

    void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + (movementInput * movementSpeed * Time.fixedDeltaTime));

    }
}
