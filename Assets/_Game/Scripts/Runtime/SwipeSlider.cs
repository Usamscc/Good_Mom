using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwipeSlider : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveX(transform.position.x + 102f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
