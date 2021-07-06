using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    private float minSpeed = 10;
    private float maxSpeed = 15;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public DifficultyButton difficultyButton;

    public int pointValue;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        RandomForce();
        RandomTorque();
        RandomSpawnPos();

        // stop targets from colliding against each other
        // NOTE: this breaks the sensor code, so add a custom layer to the sensor
        Physics.IgnoreLayerCollision(0, 0);
    }

    /* private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    } */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            if (gameObject.CompareTag("Good"))
            {
                gameManager.UpdateLives(-1);
            }
            Destroy(gameObject);
        }
    }

    void RandomForce()
    {
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
    }

    void RandomTorque()
    {
        targetRb.AddTorque(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), ForceMode.Impulse);
    }

    void RandomSpawnPos()
    {
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
}
