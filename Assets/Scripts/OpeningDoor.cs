using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    public bool openDoor = false;

    public AudioClip clip;

    private Animator animator;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor)
        {
            animator.SetTrigger("Open Door");
            source.clip = clip;
            source.Play();
        }
    }
}
