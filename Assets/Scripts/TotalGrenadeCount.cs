using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalGrenadeCount : MonoBehaviour
{
    public GameObject mainWeapon;

    private Text totalGrenadeCount;

    // Start is called before the first frame update
    void Start()
    {
        totalGrenadeCount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalGrenadeCount.text = mainWeapon.GetComponent<MainWeaponController>().grenadeAmount.ToString();
    }
}
