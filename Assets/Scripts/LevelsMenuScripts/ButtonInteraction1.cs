using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Level 2"))
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
