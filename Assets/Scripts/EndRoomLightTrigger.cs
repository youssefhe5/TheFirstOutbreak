using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoomLightTrigger : MonoBehaviour
{
    public bool turnOnLights = false;

    public GameObject sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            turnOnLights = true;
            sound.GetComponent<AudioSource>().Play();
        }
    }
}
