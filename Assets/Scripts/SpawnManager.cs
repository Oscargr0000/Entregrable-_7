using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    public GameObject Obstacle;
    public GameObject Money;
    public GameObject Bombs;

    private float StartDelay = 1f;
    private float RepeatRate = 2;

    private Vector3 SpawnPos;
    private float randomY;

    
    void Start()
    {
        InvokeRepeating("SpawnObject", StartDelay, RepeatRate);  
    }

    
    void Update()
    {
        
    }

    void SpawnObject()
    {
        randomY = Random.Range(3, 9);
        SpawnPos = new Vector3(-4, randomY, 0);

        Instantiate(Obstacle, SpawnPos, Obstacle.transform.rotation);

    }
}
