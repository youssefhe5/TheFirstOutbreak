using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickup : MonoBehaviour
{
    public AudioClip clip;

    private AudioSource source;

    private float timeToDestroy = 2f;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.GetComponentInChildren<MainWeaponController>().grenadeAmount++;
            source.clip = clip;
            source.Play();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyAmmo());
        }
    }


    IEnumerator DestroyAmmo()
    {
        yield return new WaitForSeconds(timeToDestroy);

        Destroy(this.gameObject);
    }
}
