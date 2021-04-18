using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeaponController : MonoBehaviour
{

    
    public PlayerMovement player;

    public ParticleSystem muzzleFlash;

    public ParticleSystem sparkParticles;

    public Light muzzleFlashLight;

    public GameObject bullet;
    public GameObject bulletSpawnPoint;

    public GameObject emptyMag;
    public GameObject magSpawnPoint;

    public GameObject bulletCasing;
    public GameObject bulletCasingSpawnPoint;

    public GameObject grenade;
    public GameObject grenadeSpawnPoint;

    public AudioClip takingOutWeaponSound;
    public AudioClip shootingSound;
    public AudioClip reloadAmmoLeftSound;
    public AudioClip reloadNoAmmoLeftSound;

    public Camera gunCamera;

    public bool aiming = false;
    public bool shooting = false;
    public bool reloading = false;
    public bool throwingGrenade = false;

    public int mainWeaponBulletCount = 30;
    public int maxBulletCount = 31;
    public int totalReserveBullets = 60;
    public int grenadeAmount = 2;

    private Animator animator;
    private float lastFired;
    private bool holdstered = false;
    private float timer = 0f;
    private bool longKnife = true;
    
    [SerializeField]
    private float aimZoom = 20f;
    [SerializeField]
    private float defaultZoom = 40f;
    [SerializeField]
    private float aimSpeed = 8f;
    [SerializeField]
    private float fireRate = 30f;
    [SerializeField]
    private float longKnifeTime = 1.5f;
    [SerializeField]
    private float grenadeThrowDelay = 0.2f;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = takingOutWeaponSound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        Walk();
        Run();
        HolsterWeapon();
        InspectWeapon();
        AimDownSight();
        Shoot();
        Knife();
        Reload();
        ThrowGrenade();
    }

    void Walk()
    {
        if (player.isWalking && !shooting)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

    }

    void Run()
    {
        if (player.isRunning)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

    }

    void HolsterWeapon()
    {
        if (Input.GetKeyDown(KeyCode.H) && !holdstered)
        {
            holdstered = true;
            animator.SetBool("Holster", true);
            audioSource.clip = takingOutWeaponSound;
            audioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.H) && holdstered)
        {
            holdstered = false;
            animator.SetBool("Holster", false);
            audioSource.clip = takingOutWeaponSound;
            audioSource.Play();
        }
    }

    void InspectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetTrigger("Inspect");
        }
    }


    void AimDownSight()
    {
        
        if (Input.GetMouseButton(1) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Inspect") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Knife Attack 1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Knife Attack 2") && !player.isRunning && !animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Ammo Left") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Out Of Ammo"))
        {
            aiming = true;
            animator.SetBool("Aim", true);
            gunCamera.fieldOfView = Mathf.Lerp(gunCamera.fieldOfView, aimZoom, aimSpeed * Time.deltaTime);       
            
        } else
        {
            aiming = false;
            animator.SetBool("Aim", false);
            gunCamera.fieldOfView = Mathf.Lerp(gunCamera.fieldOfView, defaultZoom, aimSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Inspect") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Knife Attack 1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Knife Attack 2") && !player.isRunning && !holdstered && mainWeaponBulletCount != 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Ammo Left") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Out Of Ammo"))
        {
            shooting = true;
            muzzleFlash.Play();
            sparkParticles.Play();
            

            if (Time.time - lastFired > 1 / fireRate)
            {
                muzzleFlashLight.enabled = true;
            } else
            {
                muzzleFlashLight.enabled = false;
            }

            if (!aiming)
            {
                if (Time.time - lastFired > 1 / fireRate)
                {
                    Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
                    Instantiate(bulletCasing, bulletCasingSpawnPoint.transform.position, bulletCasingSpawnPoint.transform.rotation);
                    mainWeaponBulletCount--;
                    lastFired = Time.time;
                    animator.Play("Fire", 0, 0f);
                    audioSource.clip = shootingSound;
                    audioSource.Play();

                }
            } else {
                if (Time.time - lastFired > 1 / fireRate)
                {
                    Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
                    Instantiate(bulletCasing, bulletCasingSpawnPoint.transform.position, bulletCasingSpawnPoint.transform.rotation);
                    mainWeaponBulletCount--;
                    lastFired = Time.time;
                    animator.Play("Aim Fire", 0, 0f);
                    audioSource.clip = shootingSound;
                    audioSource.Play();
                }
            }
            // Changed else if (!Input.GetMouseButton(0)) to just else below
        }
        else
        {
            shooting = false;
            muzzleFlash.Stop();
            muzzleFlashLight.enabled = false;
            sparkParticles.Stop();
        }
    }

    void Knife()
    {
               
        if (Input.GetKey(KeyCode.V) && !player.isRunning && !aiming && !shooting && !holdstered && !longKnife)
        {
            timer += Time.deltaTime;
            if (timer > longKnifeTime && !animator.GetCurrentAnimatorStateInfo(0).IsName("Knife Attack 2") && !player.isRunning && !aiming && !shooting && !holdstered && !longKnife && !animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Ammo Left") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Out Of Ammo"))
            {
                animator.Play("Knife Attack 1");
                longKnife = true;
            }

        } else if (Input.GetKeyUp(KeyCode.V) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Knife Attack 1") && !player.isRunning && !aiming && !shooting && !holdstered && !longKnife && !animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Ammo Left") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Out Of Ammo"))
        {
            animator.Play("Knife Attack 2");
        } else
        {
            longKnife = false;
            timer = 0f;
        }

    }

    void Reload()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Out Of Ammo") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Ammo Left"))
        {
            reloading = false;
        }
        // If weapon still has some bullets
        if (Input.GetKey(KeyCode.R) && !player.isRunning && !aiming && !shooting && !holdstered && !longKnife && mainWeaponBulletCount < maxBulletCount && mainWeaponBulletCount > 0 && !reloading && totalReserveBullets > 0)
        {
            animator.Play("Reload Ammo Left");
            audioSource.clip = reloadAmmoLeftSound;
            audioSource.Play();
            
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Ammo Left"))
            {
                if (totalReserveBullets > 0)
                {
                    int bulletsNeeded = (maxBulletCount - mainWeaponBulletCount);
                    mainWeaponBulletCount += bulletsNeeded;
                    totalReserveBullets -= bulletsNeeded;
                }

                reloading = true;
            }
        }
        //If weapon is fully empty
        else if (Input.GetKey(KeyCode.R) && !player.isRunning && !aiming && !shooting && !holdstered && !longKnife && mainWeaponBulletCount <= 0 && !reloading && totalReserveBullets > 0)
        {
            animator.Play("Reload Out Of Ammo");
            audioSource.clip = reloadNoAmmoLeftSound;
            audioSource.Play();
            
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Reload Out Of Ammo"))
            {
                if (totalReserveBullets < maxBulletCount && totalReserveBullets > 0)
                {
                    mainWeaponBulletCount = totalReserveBullets;
                    totalReserveBullets = 0;
                } else if (totalReserveBullets > 0)
                {
                    mainWeaponBulletCount = maxBulletCount - 1;
                    totalReserveBullets -= mainWeaponBulletCount;
                }
                
                Instantiate(emptyMag, magSpawnPoint.transform.position, magSpawnPoint.transform.rotation);
                reloading = true;
            }

        }
    }

    void ThrowGrenade()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("GrenadeThrow"))
        {
            throwingGrenade = false;
        }

        if (Input.GetKey(KeyCode.G) && !player.isRunning && !aiming && !shooting && !holdstered && !longKnife && !reloading && !throwingGrenade && grenadeAmount > 0)
        {
            animator.Play("GrenadeThrow");

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("GrenadeThrow"))
            {
                StartCoroutine(StartGrenadeThrow());
                grenadeAmount--;
                throwingGrenade = true;
            }

        }
    }

    IEnumerator StartGrenadeThrow()
    {
        yield return new WaitForSeconds(grenadeThrowDelay);
        Instantiate(grenade, grenadeSpawnPoint.transform.position, grenadeSpawnPoint.transform.rotation);
    }

}
