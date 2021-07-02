using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    [SerializeField] GameObject weaponHolder;
    [SerializeField] string weaponName;

    private int index; public int Index { get { return index; } }

    void Start()
    {
        for(int i = 0; i < weaponHolder.transform.childCount; i++)
        {
            if (weaponHolder.transform.GetChild(i).CompareTag(weaponName))
            {
                index = weaponHolder.transform.GetChild(i).gameObject.transform.GetSiblingIndex();
                Debug.Log(index);
            }
        }
    }

}
