using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelDebris : MonoBehaviour
{
    private float despawnDebrisTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnDebris());
    }


    IEnumerator DespawnDebris()
    {
        yield return new WaitForSeconds(despawnDebrisTime);
        Destroy(this.gameObject);
    }
}
