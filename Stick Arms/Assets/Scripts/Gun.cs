using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] RectTransform joystickHandle; public RectTransform JoystickHandle { get { return joystickHandle; } }
    [SerializeField] Joystick joystick;

    [Header("Gun Attributes")]
    [SerializeField] float speed; public float Speed { get { return speed; } }
    [SerializeField] float timeBetweenShots; public float TimeBetweenShots{ get { return timeBetweenShots; } }
    [SerializeField] float damage; public float Damage { get { return damage; } }
    [SerializeField] float movementSpeedWhileShooting; public float MovementSpeedWhileShooting { get { return movementSpeedWhileShooting; } }

    float offset;

    GameObject player;

    private void Start()
    {
        player = ((transform.parent.gameObject).transform.parent).transform.parent.gameObject;
    }

    void FixedUpdate()
    {
        rotateGun();  
    }

    void rotateGun()
    {
        if (player.transform.localScale.x > 0) //Checking if the player is facing right or left in order to change the gun rotating offset value
            offset = 180;
        else
            offset = 0;

        // Vector3 mousePos = Input.mousePosition;
        // mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //Vector2 direction = mousePos - transform.position;

        float angle = (Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg) - offset;

        if(player.transform.localScale.x > 0 && joystickHandle.anchoredPosition.x == 0 && joystickHandle.anchoredPosition.y == 0) //Checking if the player is not moving while facing the left side
        {
            angle = (Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg) - offset - 180;
        }


        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
        
    }

}
