using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretcontroller : MonoBehaviour
{
   // public float turnSpeed = 10;
    void Start()
    {
        
    }

  
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime);
    }
}
