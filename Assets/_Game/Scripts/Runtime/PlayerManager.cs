using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private PlayerMove playerMovement;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private MaleCollision malePosiiton;
    [SerializeField] private ParticleSystem confettiPS; 
    
    [Space]
    [Header("Game Variables")]
    
    
    private bool gameFinishedCrossed = false;
    private Vector3 move;
    private float movingSpeed = 1f;
    private float animationSpeed = .9f;
   
   

    private void Update()
    {
        if (GameManager.instance.GetGameOver())
        {
            MovePlayer();
          
        }else{
          
            GameManager.instance.PrintGameOver();
            confettiPS.gameObject.SetActive(true);
        }
        

    }

   

    private void MovePlayer()
    {
        //check if race line crossed and restrict user to move horizontally 
        if (!gameFinishedCrossed)
        {
             move= new Vector3(Input.GetAxis("Horizontal"), 0, movingSpeed);
        }
        else
        {
           print( transform.position);
           move= new Vector3(0, 0, movingSpeed);
        }
      
      
        playerMovement.PlayerMovement(move);
        
        UpdateWalkAnimation();
        
        //restrict user from going out of platform
        playerMovement.CheckBoundary();
    }

    
    public void HandleCollisionAnimation(CollisionType collisionType)
    {
        switch (collisionType)
        {
            case CollisionType.Male:
               HandleMaleCollision();   
                break;

            case CollisionType.Obstacles:
                HandleObstacleCollision();
                break;
            
            case CollisionType.Finish:
                gameFinishedCrossed = true;
                break;
            
            default:
                Debug.Log($"No specific animation for collision type: {collisionType}");
                break;
        }
    }
    
    private void UpdateWalkAnimation()
    {
        if (GameManager.instance.beautyPositive)
        {
            playerAnimation.WalkAnimation(animationSpeed);
           
        }
        else
        {
            playerAnimation.WalkAnimation(-animationSpeed);
           
        }
    }

    private void HandleMaleCollision()
    {
        movingSpeed = 0;
        if (GameManager.instance.beautyPositive)
        {
            playerAnimation.KissAnimation();
        }
        else
        {
                  
            playerAnimation.FallAnimation();
        }
                
        GameManager.instance.GameEnded();
    }

    private void HandleObstacleCollision()
    {
        playerAnimation.StumbleAnimation();
       
    }

   
}


