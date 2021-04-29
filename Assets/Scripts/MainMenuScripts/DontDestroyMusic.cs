using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

            DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            if (!SceneManager.GetActiveScene().name.Equals("Levels"))
            {
                Destroy(this.gameObject);
            }
                
        }
    }
}
