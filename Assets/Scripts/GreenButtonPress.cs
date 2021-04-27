using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreenButtonPress : MonoBehaviour
{
    private Animator animator;

    private float waitTimeToStartFinalScene = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player") && Input.GetKey(KeyCode.E))
        {
            animator.SetTrigger("Push");
            StartCoroutine(StartFinalScene());
        }
    }

    IEnumerator StartFinalScene()
    {
        yield return new WaitForSeconds(waitTimeToStartFinalScene);
        SceneManager.LoadScene("EscapeFacility");
    }
}
