using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1BeginLocation : MonoBehaviour
{

    private Vector3 targetPosition;

    
    void Start()
    {
        transform.position = new Vector3(-0.16f, -10.5f, 0);
        targetPosition = transform.position;
    }

   
    void Update()
    {
        
    }
}
