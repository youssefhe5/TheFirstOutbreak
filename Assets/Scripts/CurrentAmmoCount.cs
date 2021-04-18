using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentAmmoCount : MonoBehaviour
{

    public GameObject mainWeapon;

    private Text currentAmmo;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmo.text = mainWeapon.GetComponent<MainWeaponController>().mainWeaponBulletCount.ToString();
    }
}
