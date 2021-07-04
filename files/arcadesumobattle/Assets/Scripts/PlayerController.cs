using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private AudioSource playerAudio;

    private bool hasPowerup = false;
    private float powerupStrength = 2f;

    private bool hasHomingPowerup = false;
    private bool canShoot = true;
    public AudioClip boopSound;

    private bool hasSmashPowerup = false;
    private bool canSmash = false;
    private float smashForce = 30;
    private float smashRadius = 20;
    private float smashSpeed = 50;
    private float hangTime = 0.2f;
    public AudioClip explosionSound;

    public GameObject homingPrefab;
    public GameObject powerupIndicator;
    public GameObject smashPowerupIndicator;
    public GameObject homingPowerupIndicator;
    private Vector3 powerupOffset = new Vector3(0, -0.65f, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        HomingPowerup();
        SmashPowerup();

        powerupIndicator.transform.position = transform.position + powerupOffset;
        homingPowerupIndicator.transform.position = transform.position + powerupOffset;
        smashPowerupIndicator.transform.position = transform.position + powerupOffset;

        if (hasSmashPowerup && Input.GetKeyDown(KeyCode.Mouse0) && !canSmash)
        {
            canSmash = true;
            StartCoroutine(SmashPowerup());
        }
    }

    private void MovePlayer()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(focalPoint.transform.right * horizontalInput * speed);
    }

    private void HomingPowerup()
    {
        if (hasHomingPowerup && canShoot)
        {
            canShoot = false;
            Vector3 offset = new Vector3(26.54f, -10.38f, 51.98f);
            Instantiate(homingPrefab, transform.position + offset, homingPrefab.transform.rotation);
            StartCoroutine(HomingWait());
        }
    }

    IEnumerator HomingWait()
    {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    IEnumerator SmashPowerup()
    {
        var enemy1array = FindObjectsOfType<Enemy>();
        var enemy2array = FindObjectsOfType<Enemy2>();
        var bossarray = FindObjectsOfType<Boss>();

        // store y position & jump time before takeoff
        float floorY = transform.position.y;
        float jumpTime = Time.time + hangTime;
        playerAudio.PlayOneShot(explosionSound, 0.5f);

        // move the player up during jump time
        while (Time.time < jumpTime)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, smashSpeed);
            yield return null;
        }
        // smash the player downwards
        while (transform.position.y > floorY)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, -2 * smashSpeed);
            yield return null;
        }

        // apply explosion force to all enemies
        for (int i = 0; i < enemy1array.Length; i++)
        {
            if (enemy1array[i] != null)
            {
                enemy1array[i].GetComponent<Rigidbody>().AddExplosionForce(smashForce, transform.position, smashRadius, 0, ForceMode.Impulse);
            }
        }
        for (int i = 0; i < enemy2array.Length; i++)
        {
            if (enemy2array[i] != null)
            {
                enemy2array[i].GetComponent<Rigidbody>().AddExplosionForce(smashForce, transform.position, smashRadius, 0.0f, ForceMode.Impulse);
            }
        }
        for (int i = 0; i < bossarray.Length; i++)
        {
            if (bossarray[i] != null)
            {
                bossarray[i].GetComponent<Rigidbody>().AddExplosionForce(smashForce * 2, transform.position, smashRadius, 0, ForceMode.Impulse);
            }
        }

        canSmash = false;
        hasSmashPowerup = false;
        smashPowerupIndicator.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
        else if (other.CompareTag("Homing Rocket Powerup"))
        {
            Destroy(other.gameObject);
            hasHomingPowerup = true;
            homingPowerupIndicator.SetActive(true);
            StartCoroutine(HomingPowerupCountdownRoutine());
        }
        else if (other.CompareTag("Smash Powerup"))
        {
            Destroy(other.gameObject);
            hasSmashPowerup = true;
            smashPowerupIndicator.SetActive(true);
            StartCoroutine(SmashPowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    IEnumerator HomingPowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasHomingPowerup = false;
        homingPowerupIndicator.SetActive(false);
    }
    IEnumerator SmashPowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasSmashPowerup = false;
        smashPowerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDirection = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayDirection * powerupStrength * playerRb.velocity.magnitude, ForceMode.Impulse);
            playerAudio.PlayOneShot(boopSound, 1);
        }
    }
}
