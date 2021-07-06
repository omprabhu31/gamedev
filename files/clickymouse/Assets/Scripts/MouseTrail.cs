using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class MouseTrail : MonoBehaviour
{
    private GameManager gameManager;
    private Camera mainCam;
    private Vector3 mousePos;
    private TrailRenderer trail;
    private BoxCollider coll;

    public bool isSwiping = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        mainCam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        coll = GetComponent<BoxCollider>();

        trail.enabled = false;
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive && !gameManager.isGamePaused)
        {
            UpdateMousePosition();
            if (Input.GetMouseButtonDown(0))
            {
                isSwiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isSwiping = false;
                UpdateComponents();
            }
        }
    }

    void UpdateMousePosition()
    {
        mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }

    void UpdateComponents()
    {
        coll.enabled = isSwiping;
        trail.enabled = isSwiping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
            if (collision.gameObject.CompareTag("Bad") && gameManager.isHard)
            {
                gameManager.UpdateLives(-1);
            }
        }
    }
}
