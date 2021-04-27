using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{

    public GameObject lightTrigger;

    public GameObject controlPanel;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlPanel != null)
        {
            if (lightTrigger.GetComponent<EndRoomLightTrigger>().turnOnLights)
            {
                animator.SetTrigger("MoveGround");
                controlPanel.gameObject.GetComponent<Animator>().SetTrigger("MoveUp");
                if (controlPanel.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("ControlPanelMovedUp"))
                {
                    Destroy(this.gameObject);
                }
            }
        }
        
    }
}
