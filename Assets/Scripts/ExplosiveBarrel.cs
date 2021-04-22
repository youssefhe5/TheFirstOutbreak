using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{

    public GameObject explosion;
    public GameObject destroyedBarrel;
    public bool explode = false;

    [SerializeField]
    private float explosionRadius = 15f;
    [SerializeField]
    private float explosionForce = 8000F;

    // Update is called once per frame
    void Update()
    {
        if (explode)
        {
            Explode();
            explode = false;
        }
    }

    void Explode()
    {

        

        RaycastHit checkGround;
        if (Physics.Raycast(transform.position, Vector3.down, out checkGround, 50f))
        {
            Instantiate(explosion, checkGround.point + new Vector3(0,0.05f,0),
                Quaternion.FromToRotation(Vector3.forward, checkGround.normal));
        }

        Instantiate(destroyedBarrel, transform.position, transform.rotation);

        Vector3 explosionPosition = transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 3f);
            }

            if (hit.gameObject.tag.Equals("Grenade"))
            {
                hit.gameObject.GetComponent<Grenade>().explode = true;
            }

            if (hit.gameObject.tag.Equals("Target"))
            {
                hit.gameObject.GetComponent<Target>().targetHit = true;
            }

            if (hit.gameObject.tag.Equals("ExplosiveBarrel"))
            {
                hit.gameObject.GetComponent<ExplosiveBarrel>().explode = true;
            }

            if (hit.gameObject.tag.Equals("Zombie"))
            {
                hit.gameObject.GetComponent<Zombie>().die = true;
            }

            Destroy(gameObject);

        }
    }
}
