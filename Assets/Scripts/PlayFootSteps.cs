using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootSteps : MonoBehaviour
{

    public float waitTimeToWalk = 5f;

    public AudioClip clip;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
        StartCoroutine(StartWalkingSound());
    }

    IEnumerator StartWalkingSound()
    {
        yield return new WaitForSeconds(waitTimeToWalk);
        source.Play();

    }
}
