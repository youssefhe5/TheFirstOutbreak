using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public GameObject[] zombieSpawners;

    public GameObject alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            for (int i = 0; i < zombieSpawners.Length; i++)
            {
                zombieSpawners[i].GetComponent<ZombieSpawner>().gameObject.SetActive(true);
            }

            alarm.GetComponent<Alarm>().gameObject.SetActive(true);
        }
    }
}
