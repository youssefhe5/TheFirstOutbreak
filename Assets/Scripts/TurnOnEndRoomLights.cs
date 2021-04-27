using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnEndRoomLights : MonoBehaviour
{
    public GameObject lightTrigger;

    [SerializeField]
    private Light[] lights;

    [SerializeField]
    private GameObject alarm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightTrigger.GetComponent<EndRoomLightTrigger>().turnOnLights)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].gameObject.SetActive(true);
            }
            alarm.SetActive(true);
        }
    }
}
