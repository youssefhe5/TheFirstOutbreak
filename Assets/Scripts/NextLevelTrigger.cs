using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //Change to next Scence
            SceneManager.LoadScene("Level 2");

            PlayerPrefs.SetString("Level 3", "Level 2");
        }
    }
}
