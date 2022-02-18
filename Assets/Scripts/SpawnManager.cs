using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    // Random number which selects the prefab is spawning
    private int RandomPrefabNum;

    // Prefabs to spawn
    public GameObject[] ArrayObjects;

    // Timers Spawn
    private float StartDelay = 1f;
    private float RepeatRate = 0.5f;

    // Spawn position for the prefabs
    private Vector3 SpawnPos;
    private float randomY; //Random position in Y

    // Acces to the PlayerController Script
    private PlayerController PlayerControllerScript;


    void Start()
    {
        // Constant Spawn of prefabs
        InvokeRepeating("SpawnObject", StartDelay, RepeatRate);

        // Connection with the Script
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    // Function of instantiation for the prefabs
    void SpawnObject()
    {
        randomY = Random.Range(2f, 13f); // Limit Range in Y
        SpawnPos = new Vector3(-20, randomY, 0); // Spawning position for the prefabs
        RandomPrefabNum = Random.Range(0, 2); // Random selection for the prefabs


        // Stop the spawning of the prefabs if the player loses
        if (PlayerControllerScript.GameOver == false)
        {
            Instantiate(ArrayObjects[RandomPrefabNum], SpawnPos, ArrayObjects[RandomPrefabNum].transform.rotation);

        }

    }
}
