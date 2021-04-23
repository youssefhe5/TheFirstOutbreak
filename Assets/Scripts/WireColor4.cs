using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireColor4 : MonoBehaviour
{

    public Material green;

    public GameObject button;

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<objective4>().objective4Complete)
        {
            this.GetComponent<Renderer>().material = green;
        }
    }
}
