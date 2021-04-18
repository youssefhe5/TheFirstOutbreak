using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletHole;

    [SerializeField]
    private float bulletSpeed = 10f;
    [SerializeField]
    private int bulletDamage = 25;

    private float despawnBulletTime = 10f;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnBullet());
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Metal")
        {
            Instantiate(bulletHole, transform.position,
                Quaternion.LookRotation(collision.contacts[0].normal));
            
        }

        if (collision.collider.tag == "Target")
        {
            if (!collision.gameObject.GetComponent<Target>().targetHit)
            {
                collision.gameObject.GetComponent<Target>().targetHit = true;
            }
            

        }

        if (collision.collider.tag == "Grenade")
        {
            collision.gameObject.GetComponent<Grenade>().explode = true;

        }

        if (collision.collider.tag == "ExplosiveBarrel")
        {
            collision.gameObject.GetComponent<ExplosiveBarrel>().explode = true;

        }

        if (collision.collider.tag == "Zombie")
        {
            collision.collider.gameObject.GetComponent<Zombie>().health -= bulletDamage;
        }

        Destroy(this.gameObject);

    }

    IEnumerator DespawnBullet()
    {
        yield return new WaitForSeconds(despawnBulletTime);
        Destroy(this.gameObject);
    }
}
