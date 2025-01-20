using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Vertical");
        vertical = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * horizontal * speed);
        transform.Translate(Vector3.right * Time.deltaTime * vertical * 2f);
        
    }
}
