using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private float speed = 25.0f;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 reboundDirection = (collision.gameObject.transform.position - transform.position).normalized;
            float reboundMagnitude = (player.transform.position - collision.gameObject.transform.position).magnitude * 3;
            Destroy(gameObject);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(reboundDirection * reboundMagnitude, ForceMode.Impulse);
        }
    }
}
