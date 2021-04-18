using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    public AudioClip[] bulletSounds;

    private AudioSource audioSource;

    private float secondsUntilDestroyed = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnBulletImpacts());
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bulletSounds[Random.Range(0,bulletSounds.Length)];
        audioSource.Play();
    }


    IEnumerator DespawnBulletImpacts()
    {
        yield return new WaitForSeconds(secondsUntilDestroyed);
        Destroy(this.gameObject);
    }
}
