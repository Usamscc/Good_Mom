using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void WalkAnimation(float animationSpeed)
    {
        animator.SetFloat("RunningSpeed", Mathf.Abs(animationSpeed)); 
    }
}
