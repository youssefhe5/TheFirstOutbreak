using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight: MonoBehaviour
{

    public float flashLightTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlashLight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FlashLight()
    {
        yield return new WaitForSeconds(flashLightTime);
        if (this.GetComponent<Light>().enabled == true)
        {
            this.GetComponent<Light>().enabled = false;
        } else
        {
            this.GetComponent<Light>().enabled = true;
        }

        StartCoroutine(FlashLight());

    }
}
