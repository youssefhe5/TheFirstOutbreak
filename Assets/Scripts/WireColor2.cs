using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireColor2 : MonoBehaviour
{

    public Material green;

    public GameObject button;

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<objective2>().objective2Complete)
        {
            this.GetComponent<Renderer>().material = green;
        }
    }
}
