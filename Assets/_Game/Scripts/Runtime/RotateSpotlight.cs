using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpotlight : MonoBehaviour
{
    [SerializeField] private float rotationSpeed=100f;
    

    void Update()
    {
        gameObject.transform.Rotate(rotationSpeed * Time.deltaTime,0f,0);
        
    }
}
