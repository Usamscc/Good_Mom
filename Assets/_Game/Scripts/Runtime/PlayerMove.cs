using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private float vertical;
    public static bool moveFirstTime = false;
    private Animator anime;

    private void Start()
    {
        //anime = GetComponent<Animator>();
    }

    private void Update()
    {
      
        PlayerMovement();
        CheckBoundary();

        if (moveFirstTime)
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
            //anime.SetBool("IsWalking", true);

        }


    }

    private void CheckBoundary()
    {
        if (transform.position.x < -1.5f)
        {
            transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 2.2f)
        {
            transform.position = new Vector3(2.2f, transform.position.y, transform.position.z);
            
        }
    }

    private void PlayerMovement()
    {
        if (Input.GetMouseButton(0))
        {
            moveFirstTime = true;
            vertical = Input.GetAxis("Mouse X");
            transform.Translate(Vector3.right * (Time.deltaTime * 10f *vertical));
          
        }
        
    }
    
}
