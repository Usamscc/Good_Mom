using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCoin : MonoBehaviour
{
   [SerializeField] private Transform pointA,pointB;
   
 
   private float moveDuration = 2f;
   public float speed =.1f;
   
   
   void Start()
    {
        
        StartCoroutine(nameof(MoveCoinCoroutine));
        
    }
    
    
    IEnumerator MoveCoinCoroutine()
    {
        Transform targetPos = pointB;

        while (true)
        {
            
            while (Vector3.Distance(transform.position, targetPos.position) > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, targetPos.position, speed * Time.deltaTime);
                //remainingDistance -= Time.deltaTime * speed;
                yield return null; 
            }
            transform.position = targetPos.position;
            targetPos = (targetPos == pointB) ? pointA : pointB;
        }
    }
    // IEnumerator MoveCoinCoroutine()
    // {
    //     Transform targetPos = pointB; // Start moving towards pointB
    //
    //     while (true)
    //     {
    //         // While moving towards the target position
    //         while (Vector3.Distance(transform.position, targetPos.position) > 0.1f) // Use a threshold to avoid jittering
    //         {
    //             // Move the coin smoothly towards the target position
    //             transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
    //             yield return null; // Wait for the next frame
    //         }
    //
    //         // Once the coin reaches the target position, switch to the other point
    //         transform.position = targetPos.position; // Ensure the coin is exactly at the target position
    //         targetPos = (targetPos == pointB) ? pointA : pointB; // Switch target
    //     }
    // }
       
        // float elapsedTime = 0f;
        // while (true)
        // {
        //     elapsedTime += Time.deltaTime*speed;
        //     if (transform.position == pointB.position)
        //     {
        //         transform.position = Vector3.Lerp(transform.position, pointA.position, elapsedTime / moveDuration);
        //     }else {
        //         transform.position = Vector3.Lerp(transform.position, pointB.position, elapsedTime / moveDuration);
        //     }
        //     
        //     yield return null;
        // }
        // elapsedTime = 0f;
        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }

    
   

