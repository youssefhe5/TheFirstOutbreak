using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public AudioClip grenadeCollisionSound;

    public Explosion explosion;
    public Explosion explosionInAir;
    public bool explode = false;

    [SerializeField]
    private float grenadeDetonationTime = 2f;
    [SerializeField]
    private float explosionRadius = 10f;
    [SerializeField]
    private float explosionForce = 2000F;
    private AudioSource source;

    private void Awake()
    {
        GetComponent<Rigidbody>().AddRelativeTorque(Random.Range(1500, 2500),0,0);
    }


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
        StartCoroutine(ExplodeGrenade());
    }

    private void Update()
    {
        if (explode)
        {
            StopCoroutine(ExplodeGrenade());

            Explode();

            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        source.clip = grenadeCollisionSound;
        source.Play();
    }

    IEnumerator ExplodeGrenade()
    {
        yield return new WaitForSeconds(grenadeDetonationTime);

        Explode();
                

        Destroy(this.gameObject);
    }

    void Explode()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.25f))
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(explosionInAir, transform.position, transform.rotation);
        }

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

        }
    }
}
