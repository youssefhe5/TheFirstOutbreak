using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceControlPanel : MonoBehaviour
{

    public GameObject controlPanel;

    public GameObject newControlPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlPanel != null)
        {
            if (controlPanel.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("ControlPanelMovedUp"))
            {
                Instantiate(newControlPanel, controlPanel.transform.position, controlPanel.transform.rotation);
                Destroy(controlPanel);
                Destroy(this.gameObject);
            }
        }
        
    }
}
