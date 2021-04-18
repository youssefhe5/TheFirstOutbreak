using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public bool targetHit;

    public AudioClip targetDown;
    public AudioClip targetUp;


    [SerializeField]
    private float resetTime = 10f;
    private AudioSource source;
    private bool readyToCheck = true;

    private void Start()
    {
        targetHit = false;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetHit && readyToCheck)
        {
            gameObject.GetComponent<Animation>().Play("target_down");
            source.clip = targetDown;
            source.Play();
            StartCoroutine(ResetTarget());
            readyToCheck = false;
        }
    }

    IEnumerator ResetTarget()
    {
        
        yield return new WaitForSeconds(resetTime);
        
        gameObject.GetComponent<Animation>().Play("target_up");
        source.clip = targetUp;
        source.Play();
        targetHit = false;
        readyToCheck = true;
    }
}
