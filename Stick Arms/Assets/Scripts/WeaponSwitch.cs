using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] GameObject[] guns;
    [SerializeField] GameObject weaponHolder;

    private int currentWeaponIndex;
    
    void Start()
    {
        guns = new GameObject[weaponHolder.transform.childCount];

        for(int i = 0; i < guns.Length; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        currentWeaponIndex = 0;

        guns[0].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PickUpGun>())
        {
            switchGun(collision.gameObject);
            //Destroy(collision.gameObject);
            Debug.Log("Yes");
        }
    }

    void switchGun(GameObject gun)
    {
        guns[currentWeaponIndex].SetActive(false);
        currentWeaponIndex = gun.GetComponent<PickUpGun>().Index;
        guns[currentWeaponIndex].SetActive(true);
    }
}
