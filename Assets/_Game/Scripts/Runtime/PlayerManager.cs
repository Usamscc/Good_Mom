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
    [SerializeField] private ParticleSystem confettiPS;
    [SerializeField] private MaleCollision malePosiiton;
    
    [Space]
    [Header("Game Variables")]
    [SerializeField] private int obstacleEffectBeauty = 10;
    
    private bool gameFinishedCrossed = false;
    private Vector3 move;
    private float movingSpeed = 1f;
   
   

    private void Update()
    {
        if (GameManager.instance.GetGameOver())
        {
            MovePlayer();
          
        }
        else
        {
          
            GameManager.instance.PrintGameOver();
            confettiPS.gameObject.SetActive(true);
        }
        

    }

   

    private void MovePlayer()
    {
       

        if (!gameFinishedCrossed)
        {
             move= new Vector3(Input.GetAxis("Horizontal"), 0, movingSpeed);
        }
        else
        {
           transform.position=new Vector3(malePosiiton.transform.position.x, transform.position.y, transform.position.z);
           print( transform.position);
           move= new Vector3(0, 0, movingSpeed);
        }
     
        playerMovement.PlayerMovement(move);
        
        if (GameManager.instance.beautyPositive)
        {
            playerAnimation.WalkAnimation(1f);
           
        }
        else
        {
            playerAnimation.WalkAnimation(-1f);
           
        }
       
        playerMovement.CheckBoundary();
    }


    public void HandleCollisionAnimation(CollisionType collisionType)
    {
        switch (collisionType)
        {
            case CollisionType.Male:
                if (GameManager.instance.beautyPositive)
                {
                    playerAnimation.KissAnimation();
                }
                else
                {
                    StartCoroutine(WaiforMaleANimation());
                    playerAnimation.FallAnimation();
                }
                
                GameManager.instance.GameEnded();
                break;

            case CollisionType.Obstacles:
                playerAnimation.StumbleAnimation();
                GameManager.instance.BeautyScore(-obstacleEffectBeauty); 
                break;
            
            case CollisionType.Finish:
                gameFinishedCrossed = true;
                break;


            default:
                Debug.Log($"No specific animation for collision type: {collisionType}");
                break;
        }
    }

    IEnumerator WaiforMaleANimation()
    {
        yield return new WaitForSeconds(10f);
    }
}


