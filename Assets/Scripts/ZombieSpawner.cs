using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;

    public GameObject player;

    private float spawnZombieTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnZombie());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnZombie()
    {
        yield return new WaitForSeconds(spawnZombieTime);
        Debug.Log(spawnZombieTime);
        zombie.GetComponent<Zombie>().player = player;
        Instantiate(zombie, transform.position, transform.rotation);
        spawnZombieTime = Random.Range(5f, 15f);
        StartCoroutine(SpawnZombie());
    }
}
