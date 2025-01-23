using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleCollision : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            animator.SetBool("GoalReached",true);
            print("helloanimator");
        }
    }
}
