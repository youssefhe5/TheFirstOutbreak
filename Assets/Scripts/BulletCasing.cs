using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCasing : MonoBehaviour
{

    public AudioClip[] bulletCasingSounds;


    private AudioSource source;
    private float despawnCasingTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(DespawnCasings());
    }

    private void OnCollisionEnter(Collision collision)
    {
        source.clip = bulletCasingSounds[Random.Range(0, bulletCasingSounds.Length)];
        source.Play();
    }

    IEnumerator DespawnCasings()
    {
        yield return new WaitForSeconds(despawnCasingTime);
        Destroy(this.gameObject);
    }
}
