using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float speed = 10f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
