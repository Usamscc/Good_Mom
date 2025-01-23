using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MoveCoin : MonoBehaviour
{
   [SerializeField] private Transform pointA,pointB;
   private Vector3 _target;
  /// [SerializeField] private AnimationCurve movementCurve=AnimationCurve.EaseInOut(0,0,1,1); 
   
 
   private float moveDuration = 2f;
   public float speed =.1f;
   
   
   void Start()
    {
        
        StartCoroutine(nameof(MoveCoinCoroutine));
        
    }
    
    
    IEnumerator MoveCoinCoroutine()
    {
        //float TT=movementCurve.Evaluate(speed * Time.deltaTime);
        Transform targetPos = pointB;

        while (true)
        {
            
            while (transform.position != targetPos.position)
            {
                transform.position = Vector3.Lerp(transform.position, targetPos.position,speed * Time.deltaTime );
                //remainingDistance -= Time.deltaTime * speed;
                yield return null; 
            }
            transform.position = targetPos.position;
            targetPos = (targetPos == pointB) ? pointA : pointB;
        }
    }

   

    private void OnDisable()
        {
            StopAllCoroutines();
        }
    }

   