using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCredits : MonoBehaviour
{

    public float cutSceneLength = 20f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCredits());   
    }

    IEnumerator StartCredits()
    {
        yield return new WaitForSeconds(cutSceneLength);
        SceneManager.LoadScene("Credits");
    }
}
