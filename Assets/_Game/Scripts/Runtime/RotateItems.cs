using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
    [SerializeField]  private float rotationSpeed=100f;

    private void Start()
    {
        rotationSpeed = 100f;
    }

    void Update()
   {
      gameObject.transform.Rotate(0,rotationSpeed * Time.deltaTime,0);
   }
}
