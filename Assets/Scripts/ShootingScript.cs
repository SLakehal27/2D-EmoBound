using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Needs objet pooling lmao
            Instantiate(bullet, firePoint.position,Quaternion.identity);
        }
    }
}
