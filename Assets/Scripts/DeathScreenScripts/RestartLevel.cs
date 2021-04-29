using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public void Restart()
    {
        if (GameObject.Find("Level 1"))
        {
            SceneManager.LoadScene("Demo 1");
        } else if (GameObject.Find("Level 2"))
        {
            SceneManager.LoadScene("Level 1");
        } else if (GameObject.Find("Level 3"))
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
