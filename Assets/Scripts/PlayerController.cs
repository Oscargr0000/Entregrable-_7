using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Physics
    private Rigidbody PlayerRigidbody;
    private float JumpForce = 600;
    private Vector3 GravityForce = new Vector3(0,-20f,0);

    // limit of palyer
    private float yLimit = 14f;

    // Recolected Points
    private float MoneyCounter;

    // AudioClips
    public AudioClip jumpClip;
    public AudioClip CrashClip;
    public AudioClip ColectionClip;

    // AudioSorces
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;

    // Particles
    public ParticleSystem ExplosionParticle;
    public ParticleSystem ColectionParticle;

    // Game Over
    public bool GameOver;

    void Start()
    {
        //RigidBody acces
        PlayerRigidbody = GetComponent<Rigidbody>();

        //Gravity
        Physics.gravity = GravityForce;

        //Acces to Player -> AudioSource
        playerAudioSource = GetComponent<AudioSource>();

        //Acces to Camera -> AudioSource
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }


    void Update()
    {
        // Player Limit High
        if(transform.position.y >= yLimit)
        {
            transform.position = new Vector3(transform.position.x, yLimit, transform.position.z);
        }

        // Basic Movement
        if (Input.GetKeyDown(KeyCode.Space) && GameOver == false)
        {
            PlayerRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

           
        }

        // Destroy player after losing
        if(GameOver == true)
        {
            Destroy(gameObject);

        }
    }

    // Collision with the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Game Over"); // Print game over

            
            playerAudioSource.PlayOneShot(CrashClip, 1); // SFX Crashing sound
            cameraAudioSource.volume = 0; 

            Instantiate(ExplosionParticle, transform.position, transform.rotation); // Explosion if the player touch the ground

            GameOver = true; // Activate Game Over
        }
    }


    // Collision with the items
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Debug.Log("Game Over"); // Print Game Over

            playerAudioSource.PlayOneShot(CrashClip, 1); // SFX Crashing 
            cameraAudioSource.volume = 0; // Desactivate the music if the player loses

            Instantiate(ExplosionParticle, transform.position, transform.rotation); // Explosion if the player touch the Bomb

            Destroy(collision.gameObject); // Destroy the item which is being touched by the player

            GameOver = true; // Activate Game Over
            
        }

        if (collision.gameObject.CompareTag("Money"))
        {
            MoneyCounter++;

            Debug.Log(MoneyCounter); // Print Game Over

            playerAudioSource.PlayOneShot(ColectionClip, 1); // SFX Jumping

            Instantiate(ColectionParticle, transform.position, transform.rotation); // VFX Collecting Money

            Destroy(collision.gameObject); //  Destroy the item which is being touched by the player
        }
    }
}
