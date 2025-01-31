using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MoveCoin : MonoBehaviour
{
    [SerializeField] private Transform pointA,pointB;
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
               
                yield return null; 
            }
            
            targetPos = (targetPos == pointB) ? pointA : pointB;
        }
    }

   

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}