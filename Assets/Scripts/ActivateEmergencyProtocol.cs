using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEmergencyProtocol : MonoBehaviour
{
    public bool protocolActivated = false;

    [SerializeField]
    private AudioClip clip;

    private AudioSource source;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player") && Input.GetKey(KeyCode.E))
        {
            animator.SetBool("Push", true);
            source.clip = clip;
            source.Play();
            protocolActivated = true;

        }
    }
}
