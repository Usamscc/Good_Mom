using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void WalkAnimation(float animationSpeed)
    {
        animator.SetFloat("RunningSpeed", animationSpeed); 
    }

    public void KissAnimation()
    {
        animator.SetBool("GoalReached",true);
    }

    public void FallAnimation()
    {
        animator.SetTrigger("BadScore");
    }
    
    public void StumbleAnimation()
    {
        animator.SetTrigger("Stumble");
    }
}
