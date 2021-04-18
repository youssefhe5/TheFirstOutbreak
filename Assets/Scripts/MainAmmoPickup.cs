using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAmmoPickup : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.GetComponentInChildren<MainWeaponController>().totalReserveBullets += 30;
            Destroy(gameObject);
        }
        
    }
}
