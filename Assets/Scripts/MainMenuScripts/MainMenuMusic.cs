using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{

    public AudioClip[] clips;

    private AudioSource source;

    private int currentClip = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        source = GetComponent<AudioSource>();
        source.clip = clips[currentClip];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            if (clips.Length-1 > currentClip)
            {
                currentClip++;
                source.clip = clips[currentClip];
                source.Play();
            } else
            {
                currentClip = 0;
                source.clip = clips[currentClip];
                source.Play();
            }
            
        }
    }
}
