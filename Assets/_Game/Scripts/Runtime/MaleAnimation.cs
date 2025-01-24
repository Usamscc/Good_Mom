using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void KissAnimation()
    {
        animator.SetBool("GoalReached",true);
    }
}
