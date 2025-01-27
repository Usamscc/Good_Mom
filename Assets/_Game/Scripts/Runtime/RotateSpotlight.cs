using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpotlight : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = .1f;
    void Update()
    {
        gameObject.transform.Rotate(rotationSpeed,0f,0);
        
    }
}
