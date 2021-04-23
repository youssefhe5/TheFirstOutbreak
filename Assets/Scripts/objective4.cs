using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objective4 : MonoBehaviour
{

    public bool objective4Complete = false;

    public Material green;

    private bool canPressButton = false;
    private Animator animator;
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
            this.GetComponent<Renderer>().material = green;
            objective4Complete = true;
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
