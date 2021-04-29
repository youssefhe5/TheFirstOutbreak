using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlasher : MonoBehaviour
{

    public GameObject muzzleFlash;

    private float muzzleFlashWaitTIme = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MuzzleFlash());
    }


    IEnumerator MuzzleFlash()
    {
        yield return new WaitForSeconds(muzzleFlashWaitTIme);
        if (muzzleFlash.activeSelf)
        {
            muzzleFlash.SetActive(false);
        } else
        {
            muzzleFlash.SetActive(true);
        }
        
        StartCoroutine(MuzzleFlash());
    }
}
