using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
   [SerializeField] private float rotationSpeed=.2f;
   
   void Update()
   {
      gameObject.transform.Rotate(0,rotationSpeed,0);
   }
}
