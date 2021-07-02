using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ThreeBulletFire : MonoBehaviour
{
    [SerializeField] AudioClip fireSound;
    [SerializeField] Transform shootingPointUpper;
    [SerializeField] Transform shootingPointMiddle;
    [SerializeField] Transform shootingPointLower;
    [SerializeField] Gun gun;
    [SerializeField] Projectile projectile;
    [SerializeField] ParticleSystem fireEffect;
    [SerializeField] float shakeMagnitude;
    [SerializeField] float shakeDuration;

    float currentTimeBetweenShots;
    Vector3 localPos;
    PlayerMovement player;

    private void Start()
    {
        localPos = transform.localPosition;
        player = ((transform.parent.gameObject).transform.parent).transform.parent.gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        shoot();

        if (gun.JoystickHandle.anchoredPosition.x == 0 && gun.JoystickHandle.anchoredPosition.y == 0)
        {
            transform.localPosition = localPos;
            player.MovementSpeed = player.OriginalSpeed;
        }
    }

    void shoot()
    {
        if (currentTimeBetweenShots <= 0 && (gun.JoystickHandle.anchoredPosition.x != 0 || gun.JoystickHandle.anchoredPosition.y != 0)) //Checking if the gun timer is up and the fire joystick is being used
        {
            Projectile p1 = Instantiate(projectile, shootingPointUpper.position, shootingPointUpper.rotation); //Three bullets in 3 directions
            Projectile p2 = Instantiate(projectile, shootingPointMiddle.position, shootingPointMiddle.rotation);
            Projectile p3 = Instantiate(projectile, shootingPointLower.position, shootingPointLower.rotation);
            ParticleSystem ps = Instantiate(fireEffect, shootingPointMiddle.position, Quaternion.identity);
            CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeMagnitude, shakeDuration, shakeDuration);
            transform.Translate(transform.right * 0.2f); //Shake the gun while shooting
            Invoke("goBack", 0.05f); //Put back the gun to original poisition
            Destroy(ps, 1f);
            AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position);

            if (player.transform.localScale.x > 0) //Setting the isLeft boolean depedning on the gun
            {
                p1.isLeft = true;
                p2.isLeft = true;
                p3.isLeft = true;
            }
                
            else
            {
                p1.isLeft = false;
                p2.isLeft = false;
                p3.isLeft = false;
            }

            currentTimeBetweenShots = gun.TimeBetweenShots;
            player.MovementSpeed = gun.MovementSpeedWhileShooting;
        }

        

        currentTimeBetweenShots -= Time.deltaTime;
    }


    void goBack()
    {
        transform.Translate(-(transform.right * 0.2f));
    }
}
