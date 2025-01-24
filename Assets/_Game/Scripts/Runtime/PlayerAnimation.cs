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

    public void KissAnimation()
    {
        animator.SetBool("GoalReached",true);
    }

    public bool GoalReached()
    {
        return !animator.GetBool("GoalReached");
    }

    public void StumbleAnimation()
    {
        animator.SetTrigger("Stumble");
    }
}
