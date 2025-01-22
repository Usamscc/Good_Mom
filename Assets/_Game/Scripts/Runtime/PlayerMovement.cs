using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    float horizontal;
    float vertical;

    private float speed=0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed += 0.4f;
            animator.SetFloat("RunningSpeed",speed );
            
        }
        print(speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        print(other.gameObject.name);
           // speed -= 1;

        
    }
}
