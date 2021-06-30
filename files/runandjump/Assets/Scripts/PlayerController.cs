using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private float jumpForce = 550;
    private float doubleJumpForce = 300;
    private float gravityModifier = 1.5f;
    public bool gameOver = false;
    private int maxJumps = 2;
    public int jumps;

    public float score;
    private float scoreMultiplier = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Get player components
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            PlayerJump();
        }

        TrackScore();
    }

    private void TrackScore()
    {
        if (!gameOver && !Input.GetKey(KeyCode.LeftShift))
        {
            score += (scoreMultiplier * Time.deltaTime);
        }
        else if (!gameOver && Input.GetKey(KeyCode.LeftShift))
        {
            score += (2 * scoreMultiplier * Time.deltaTime);
        }
        else
        {
            return;
        }
    }

    private void PlayerJump()
    {
        // Player jump actions (double jump, animation, particle stop, sound)
        if (jumps == 2)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumps -= 1;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 2);
        }
        else if (jumps == 1)
        {
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            jumps -= 1;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 2);
        }
        else
        {
            return;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Allow player to jump only when on the ground
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            jumps = maxJumps;
            dirtParticle.Play();
        }
        // Obstacle collision actions (disable jump, animation, particles, sound)
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.5f);
        }
    }
}
