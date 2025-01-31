using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private CharacterController controller;
    
    [Space]
    [Header("Variables")]
    [SerializeField] private float playerSpeed = 2f;
    [SerializeField] private Vector2 xBoundary=new Vector2( -1.5f, 2.2f);
    
    public void CheckBoundary()
    {
        if (transform.position.x < xBoundary.x)
        {
            transform.position = new Vector3(xBoundary.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBoundary.y)
        {
            transform.position = new Vector3(xBoundary.y, transform.position.y, transform.position.z);
            
        }
    }

    public void PlayerMovement(Vector3 move)
    {
        
        controller.Move(move * Time.deltaTime * playerSpeed);
        
    }

    public void PlayerMovementTowards(Vector3 targetPosition)
    {
        controller.Move(targetPosition * Time.deltaTime * playerSpeed);
    }
   
    
}
