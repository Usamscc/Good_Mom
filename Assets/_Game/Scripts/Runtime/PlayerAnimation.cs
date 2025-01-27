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
        StartCoroutine(WaiforMaleANimation());   
       
    }
    
    public void StumbleAnimation()
    {
        animator.SetTrigger("Stumble");
    }
    
    IEnumerator WaiforMaleANimation()
    {
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("BadScore");
    }
}
