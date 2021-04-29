using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{

    public GameObject pauseMenuUI;

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
    }
}
