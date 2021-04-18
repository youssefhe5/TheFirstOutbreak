using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public int health = 100;
    public GameObject ragdoll;


    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(ragdoll, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
