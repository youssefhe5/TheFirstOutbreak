using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Level 3")){
            this.gameObject.SetActive(false);
        }
    }
}
