using UnityEngine;

public class MaleCollision : MonoBehaviour
{
    [SerializeField] private MaleAnimation maleAnimation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.beautyPositive)
                maleAnimation.KissAnimation();
            else
                maleAnimation.KickAnimation();
        }
    }
}
