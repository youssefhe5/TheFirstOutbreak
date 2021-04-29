using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTriggerDemo1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //Change to next Scence
            SceneManager.LoadScene("Level 1");

            PlayerPrefs.SetString("Level 2", "Level 1");
        }
    }
}
