using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireColor3 : MonoBehaviour
{

    public Material green;

    public GameObject button;

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<objective3>().objective3Complete)
        {
            this.GetComponent<Renderer>().material = green;
        }
    }
}
