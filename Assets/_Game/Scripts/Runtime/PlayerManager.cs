using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMovement;
    [SerializeField] private PlayerAnimation playerAnimation;
   

    private void Update()
    {
        if (GameManager.instance.GetGameOver())
        {
            MovePlayer();
          
        }
        else
        {
          
            GameManager.instance.PrintGameOver();
        }
        

    }

   

    private void MovePlayer()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerMovement.PlayerMovement(move);
        playerAnimation.WalkAnimation(Input.GetAxis("Vertical"));
        playerMovement.CheckBoundary();
    }


    public void HandleCollisionAnimation(CollisionType collisionType)
    {
        switch (collisionType)
        {
            case CollisionType.Male:
                playerAnimation.KissAnimation();
                GameManager.instance.GameEnded();
                break;

            case CollisionType.Obstacles:
                playerAnimation.StumbleAnimation();
                GameManager.instance.BeautyScore(10); // Keep the BeautyScore logic here
                break;


            default:
                Debug.Log($"No specific animation for collision type: {collisionType}");
                break;
        }
    }
}


