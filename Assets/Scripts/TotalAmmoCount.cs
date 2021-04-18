using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalAmmoCount : MonoBehaviour
{

    public GameObject mainWeapon;

    private Text totalAmmoCount;


    // Start is called before the first frame update
    void Start()
    {
        totalAmmoCount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalAmmoCount.text = mainWeapon.GetComponent<MainWeaponController>().totalReserveBullets.ToString();
    }
}
