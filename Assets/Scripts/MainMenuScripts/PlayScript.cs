using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        if (PlayerPrefs.HasKey("Level 3"))
        {
            SceneManager.LoadScene("Level 2");
        } else if (PlayerPrefs.HasKey("Level 2"))
        {
            SceneManager.LoadScene("Level 1");
        } else
        {
            SceneManager.LoadScene("Demo 1");
        }
    }
}
