using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MainWeaponController mainWeaponController;

    public bool isWalking;
    public bool isRunning;

    //Audio Source
    private AudioSource source;

    //Audio clips
    public AudioClip walkingSound;
    public AudioClip runningSound;

    public GameObject pauseMenu;

    [SerializeField]
    private float walkingSpeed = 4f;

    [SerializeField]
    private float runningSpeed = 6f;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float rayCastDistance = 1.4f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        isWalking = false;
        isRunning = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.activeSelf)
        {
            Jump();
            StartSound();
        }
    }

    private void FixedUpdate()
    {
        

        if (Input.GetKey(KeyCode.LeftShift) && !mainWeaponController.aiming)
        {
            Run();
        } else
        {
            Walk();
        }
    }

    private void Walk()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalAxis, 0, verticalAxis) * walkingSpeed * Time.fixedDeltaTime;

        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);

        if (movement.x != 0 || movement.z != 0)
        {
            isWalking = true;
            isRunning = false;

        } else
        {
            isWalking = false;
            isRunning = false;
        }
        

        rb.MovePosition(newPosition);
    }

    private void Run()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalAxis, 0, verticalAxis) * runningSpeed * Time.fixedDeltaTime;

        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);

        if (movement.x != 0 || movement.z != 0)
        {
            isRunning = true;
            isWalking = false;
        } else
        {
            isRunning = false;
            isWalking = false;
        }

        rb.MovePosition(newPosition);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
            
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayCastDistance);
    }

    private void StartSound()
    {
        if (IsGrounded())
        {
            if (isWalking)
            {
                if (!source.isPlaying || source.clip == runningSound)
                {
                    source.clip = walkingSound;
                    source.Play();
                }
                
            } else if (isRunning)
            {
                if (!source.isPlaying || source.clip == walkingSound)
                {
                    source.clip = runningSound;
                    source.Play();
                }
                
            } else
            {
                source.Pause();
            }
        } else
        {
            source.Stop();
        }
        
    }
}
