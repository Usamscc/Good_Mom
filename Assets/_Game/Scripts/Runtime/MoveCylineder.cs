using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCylineder : MonoBehaviour
{
    private float horizontal;
    private float vertical;
   

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
}
