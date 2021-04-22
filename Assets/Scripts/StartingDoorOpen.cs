using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDoorOpen : MonoBehaviour
{

    public GameObject button;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<Button>().openDoor)
        {
            animator.SetTrigger("OpenDoor");
        }
        
    }
}
