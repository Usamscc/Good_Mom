using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MoveCoin : MonoBehaviour
{
    [SerializeField] private Transform pointA,pointB;
    [SerializeField] private float speed =.1f;
  
  
    void Start()
    {
        transform.position =new Vector3(pointA.position.x,transform.position.y,transform.position.z);
        transform.DOMoveX(pointB.position.x,speed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        // StartCoroutine(MoveCoinCoroutine());
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