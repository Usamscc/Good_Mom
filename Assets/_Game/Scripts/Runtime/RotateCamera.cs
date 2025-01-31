using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject target;

    private void Update()
    {
        camera.transform.RotateAround(target.transform.position,Vector3.up, 1f);
    }
}
