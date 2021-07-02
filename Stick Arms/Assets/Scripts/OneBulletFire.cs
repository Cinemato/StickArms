using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class OneBulletFire : MonoBehaviour
{
    [SerializeField] AudioClip fireSound;
    [SerializeField] Transform shootingPoint;
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

        if(gun.JoystickHandle.anchoredPosition.x == 0 && gun.JoystickHandle.anchoredPosition.y == 0)
        {
            transform.localPosition = localPos;
            player.MovementSpeed = player.OriginalSpeed;
        }
    }

    void shoot()
    {
        if (currentTimeBetweenShots <= 0 && (gun.JoystickHandle.anchoredPosition.x != 0 || gun.JoystickHandle.anchoredPosition.y != 0)) //Checking if the gun timer is up and the fire joystick is being used
        {
            Projectile p = Instantiate(projectile, shootingPoint.position, transform.rotation);
            ParticleSystem ps = Instantiate(fireEffect, shootingPoint.position, Quaternion.identity);
            CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeMagnitude, shakeDuration, shakeDuration);
            transform.Translate(transform.right * 0.05f); //Shake the gun while shooting
            Invoke("goBack", 0.05f);
            Destroy(ps, 2f);
            AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position);

            if (player.transform.localScale.x > 0) //Setting the isLeft boolean depedning on the gun
                p.isLeft = true;
            else
                p.isLeft = false;

            currentTimeBetweenShots = gun.TimeBetweenShots;
            player.MovementSpeed = gun.MovementSpeedWhileShooting;
        } 

        currentTimeBetweenShots -= Time.deltaTime;
    }

    void goBack() //Put back the gun to original poisition
    {
        transform.Translate(-(transform.right * 0.05f));
    }

}


