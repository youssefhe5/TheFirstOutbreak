using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExitDoor : MonoBehaviour
{
    public bool openDoor = false;

    private Animator animator;

    private bool canPressButton = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (canPressButton && Input.GetKey(KeyCode.E))
        {
            animator.SetBool("Push", true);
            openDoor = true;
        }
        else
        {
            animator.SetBool("Push", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            canPressButton = true;

        }
        else
        {
            canPressButton = false;
        }
    }
}
