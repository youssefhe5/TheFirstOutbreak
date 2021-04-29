using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeAmmoRespawn : MonoBehaviour
{

    public GameObject magazine;
    public GameObject grenade;

    [SerializeField]
    private float ammoSpawnCount = 120f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAmmo());
    }

    IEnumerator SpawnAmmo()
    {
        yield return new WaitForSeconds(ammoSpawnCount);
        Instantiate(magazine, transform.position, transform.rotation);
        Instantiate(magazine, transform.position, transform.rotation);
        Instantiate(magazine, transform.position, transform.rotation);
        Instantiate(magazine, transform.position, transform.rotation);
        Instantiate(magazine, transform.position, transform.rotation);
        Instantiate(magazine, transform.position, transform.rotation);
        Instantiate(magazine, transform.position, transform.rotation);
        Instantiate(magazine, transform.position, transform.rotation);
        Instantiate(grenade, transform.position, transform.rotation);
        Instantiate(grenade, transform.position, transform.rotation);
        Instantiate(grenade, transform.position, transform.rotation);
        Instantiate(grenade, transform.position, transform.rotation);
        StartCoroutine(SpawnAmmo());
    }
}
