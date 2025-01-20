using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
   void Update()
   {
      gameObject.transform.Rotate(0,.2f,0);
   }
}
