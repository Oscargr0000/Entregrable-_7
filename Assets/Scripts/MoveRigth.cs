using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigth : MonoBehaviour
{
    // Movement Speed for the items
    private float speed = 10f;

    // Time of life for items
    private float timeDestroy = 5f;

    // Acces for the Controls of the Player
    private PlayerController PlayerControllerScript;


    void Start()
    {
        // Conection with the Script
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.Translate(speed * Vector3.right * Time.deltaTime); // Movement of the items


        Destroy(gameObject, timeDestroy); // Destroy the object after 5 Seconds

        if (PlayerControllerScript.GameOver == true) // When the player loses, the items stop moving
        {
            speed = 0;

        }
    }
}
