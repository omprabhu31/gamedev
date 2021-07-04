using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 15.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private SpawnManager spawnManager;
    public GameObject bossBabyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        InvokeRepeating("SpawnBossBaby", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        DestroyEnemy();
    }

    private void FollowPlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }

    private void DestroyEnemy()
    {
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 relativeVelocity = (enemyRb.velocity - collision.gameObject.GetComponent<Rigidbody>().velocity);
            Vector3 forceDir = (player.transform.position - transform.position).normalized * relativeVelocity.magnitude;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(forceDir.x, 0, forceDir.z), ForceMode.Impulse);
        }
    }

    private void SpawnBossBaby()
    {
        Instantiate(bossBabyPrefab, spawnManager.GetRandomPosition(), bossBabyPrefab.transform.rotation);
    }
}
