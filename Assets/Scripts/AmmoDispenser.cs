using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDispenser : MonoBehaviour
{
    public Material green;
    public Material red;

    public GameObject magazine;
    public GameObject grenade;

    private bool canPressButton = false;
    private Animator animator;

    private float timeToSpawn = 5f;
    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (canSpawn)
        {
            if (other.tag.Equals("Player") && Input.GetKey(KeyCode.E))
            {
                animator.SetBool("Push", true);
                GetComponent<Renderer>().material = red;
                canSpawn = false;
                Instantiate(magazine, transform.position, transform.rotation);
                Instantiate(grenade, transform.position, transform.rotation);
                StartCoroutine(SpawnAmmo());
            }
        }
        
    }

    IEnumerator SpawnAmmo()
    {
        yield return new WaitForSeconds(timeToSpawn);

        GetComponent<Renderer>().material = green;
        canSpawn = true;
    }
}
