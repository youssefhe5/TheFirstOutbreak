using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLargeGate : MonoBehaviour
{

    public GameObject objective1;
    public GameObject objective2;
    public GameObject objective3;
    public GameObject objective4;
    public GameObject objective5;

    public GameObject[] zombieSpawners;

    public GameObject alarm;

    public GameObject exitDoorButton;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objective1.GetComponent<objective1>().objective1Complete && objective2.GetComponent<objective2>().objective2Complete && objective3.GetComponent<objective3>().objective3Complete && objective4.GetComponent<objective4>().objective4Complete
            && objective5.GetComponent<objective5>().objective5Complete)
        {
            animator.SetTrigger("ObjectivesSecured");
            for (int i = 0; i < zombieSpawners.Length; i++)
            {
                Destroy(zombieSpawners[i]);
            }
            Destroy(alarm);
            exitDoorButton.SetActive(true);
        }
    }
}
