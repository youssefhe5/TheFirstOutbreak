using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
