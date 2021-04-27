using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyProtocolListener : MonoBehaviour
{

    public GameObject emergencyProtocol;

    public GameObject doorOpenButton;

    // Update is called once per frame
    void Update()
    {
        if (emergencyProtocol.GetComponent<ActivateEmergencyProtocol>().protocolActivated)
        {
            doorOpenButton.SetActive(true);
        }
    }
}
