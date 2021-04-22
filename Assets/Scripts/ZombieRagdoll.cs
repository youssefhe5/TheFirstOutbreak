using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRagdoll : MonoBehaviour
{
    private float despawnBodyTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnBody());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator DespawnBody()
    {
        yield return new WaitForSeconds(despawnBodyTime);
        Destroy(this.gameObject);
    }
}
