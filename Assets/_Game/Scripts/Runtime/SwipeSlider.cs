using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwipeSlider : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB;
    [SerializeField] private float duration=2f;
    private void Start()
    {
        transform.position =new Vector3(pointA.position.x,transform.position.y,transform.position.z);
        transform.DOMoveX(pointB.position.x, duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
