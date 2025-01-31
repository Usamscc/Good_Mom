using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HeartBeatDotween : MonoBehaviour
{
    void Start() => transform.DOScale(0.79f, 0.5f).SetEase(Ease.InCirc).SetLoops(-1, LoopType.Yoyo);
}
