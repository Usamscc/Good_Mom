
using UnityEngine;

public class MaleAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void KissAnimation()
    {
        animator.SetBool("GoalReached",true);
    }

    public void KickAnimation()
    {
        animator.SetTrigger("BadScore");
    }
}
