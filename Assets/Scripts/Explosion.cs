using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public AudioClip[] explosionSounds;
    
    public Light lightFlash;

    private AudioSource source;
    private float lightFlashTime = 0.02f;
    private float despawn = 10f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateLight());
        StartCoroutine(DestroyExplosion());

        source = GetComponent<AudioSource>();
        source.clip = explosionSounds[Random.Range(0, explosionSounds.Length)];
        source.Play();
    }

    IEnumerator ActivateLight()
    {
        lightFlash.GetComponent<Light>().enabled = true;

        yield return new WaitForSeconds(lightFlashTime);

        lightFlash.GetComponent<Light>().enabled = false;

    }

    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(despawn);
        Destroy(this.gameObject);
    }
}
