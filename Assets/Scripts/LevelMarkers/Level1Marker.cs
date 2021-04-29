using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Marker : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Level 1");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Level 1"))
        {
            Destroy(this.gameObject);
        }
    }
}
