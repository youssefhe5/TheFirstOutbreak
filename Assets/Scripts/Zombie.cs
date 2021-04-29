using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Zombie : MonoBehaviour
{

    public AudioClip[] zombieSounds;

    public int health = 100;

    public float strikingDistance = 1.5f;
    public float chasingDistance = 50f;

    public bool die = false;

    public GameObject ragdoll;

    public GameObject player;

    public NavMeshAgent agent;

    private Animator animator;

    private AudioSource source;

    private float timeToMakeNoises = 5f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        timeToMakeNoises = Random.Range(5f, 20f);
        StartCoroutine(MakeZombieNoises());
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            //Chase
            if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < chasingDistance)
            {
                agent.SetDestination(player.transform.position);
                animator.SetBool("RunningZombie", true);
                animator.SetBool("AttackingZombie", false);
                this.GetComponent<BoxCollider>().enabled = false;
            } else
            {
                animator.SetBool("RunningZombie", false);
                this.GetComponent<BoxCollider>().enabled = false;
            }

            //Attack
            if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < strikingDistance)
            {
                animator.SetBool("RunningZombie", false);
                animator.SetBool("AttackingZombie", true);
                this.GetComponent<BoxCollider>().enabled = true;

            }
        }

       

        if (health <= 0 || die)
        {
            Instantiate(ragdoll, transform.position, transform.rotation);
            die = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("You died");
            SceneManager.LoadScene("Death");
        }

        if (other.tag.Equals("Knife"))
        {
            health -= 5;
        }
    }

    IEnumerator MakeZombieNoises()
    {
        yield return new WaitForSeconds(timeToMakeNoises);
        timeToMakeNoises = Random.Range(5f, 30f);
        source.clip = zombieSounds[Random.Range(0,8)];
        source.Play();
        StartCoroutine(MakeZombieNoises());
    }
}
