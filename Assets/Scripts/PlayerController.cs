using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRigidbody;
    private float JumpForce = 600;
    private Vector3 GravityForce = new Vector3(0,-20f,0);

    private float yLimit = 14f;
    private float MoneyCounter;
    
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity = GravityForce;
    }


    void Update()
    {

        if(transform.position.y >= yLimit)
        {
            transform.position = new Vector3(transform.position.x, yLimit, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        //Game Over

        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Game Over");

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
        }

        if (collision.gameObject.CompareTag("Money"))
        {
            MoneyCounter++;
            Debug.Log(MoneyCounter);
        }
    }
}
