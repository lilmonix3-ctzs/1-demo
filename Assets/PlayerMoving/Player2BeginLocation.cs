using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2BeginLocation : MonoBehaviour
{
    private Vector3 targetPosition;
   
    void Start()
    {
        transform.position = new Vector3(0, 0.1f, 0);
        targetPosition = transform.position;
    }

   
    void Update()
    {
        
    }
}
