using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireColor5 : MonoBehaviour
{

    public Material green;

    public GameObject button;

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<objective5>().objective5Complete)
        {
            this.GetComponent<Renderer>().material = green;
        }
    }
}
