using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
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
            Vector3 relativeVelocity = (enemyRb.velocity - collision.gameObject.GetComponent<Rigidbody>().velocity) * 0.5f;
            Vector3 forceDir = (player.transform.position - transform.position).normalized * relativeVelocity.magnitude;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(forceDir, ForceMode.Impulse);
        }
    }
}
