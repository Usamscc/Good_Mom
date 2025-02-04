using System;
using UnityEngine;



public class PlayerManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private PlayerMove playerMovement;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private MaleCollision malePosiiton;
    [SerializeField] private ParticleSystem confettiPS;
    [SerializeField] private FixedTouchField fixedTouchField;
    // [SerializeField] private GameObject coins;
    // [SerializeField] private GameObject coinPrefab;
    
    [Header("Game Variables")]
    [SerializeField] private float movingSpeed = 1f;
    [SerializeField] private float horizontalSpeed = 500f;
    [SerializeField] private float animationSpeed = .9f;
    
    private bool isactive=true;
    private bool gameFinishedCrossed = false;
    private Vector3 move;
   
    private Vector3 dist;

    private void Start()
    {
        SendLevelDisatance();
        print("Screen.width "+Screen.width);
        // Instantiate(coinPrefab,coins.transform);
    }

    private void SendLevelDisatance()
    {
      GameManager.instance.FullLevelDistance(Vector3.Distance(playerMovement.transform.position, malePosiiton.transform.position));
    }

    private void Update()
    { 
       
        if (GameManager.instance.GetGameOver())
        {
            MovePlayer();
          
        }
        GameManager.instance.RemainingLevelDistance(transform,malePosiiton.transform);
        
    }

    private void MovePlayer()
    {
        if (fixedTouchField.isDragged)
        {
            GameManager.instance.StartGame();
        }
       
        if (GameManager.instance.isGameStarted)
        {
            //check if race line crossed and restrict user to move horizontally 
            if (gameFinishedCrossed)
            {
                dist = (malePosiiton.transform.position - transform.position).normalized;
                playerMovement.PlayerMovementTowards(dist);
            }
            else
            {
                
                // move = new Vector3(Input.GetAxis("Horizontal"), 0, movingSpeed);
                move = new Vector3(fixedTouchField.TouchDist.x * horizontalSpeed *Time.deltaTime, 0, movingSpeed);
                playerMovement.PlayerMovement(move);
            }

            UpdateWalkAnimation();
        }

        //restrict user from going out of platform
        playerMovement.CheckBoundary();
        
    }

    
    public void HandleCollisionAnimation(CollisionType collisionType)
    {
        switch (collisionType)
        {
            case CollisionType.Male:
               HandleMaleCollision(); 
               GameManager.instance.GameEnded();
                break;

            case CollisionType.Obstacles:
                HandleObstacleCollision();
                break;
            
            case CollisionType.Finish:
                gameFinishedCrossed = true;
                GameManager.instance.SaveData();
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
            confettiPS.gameObject.SetActive(true);
        }
        else
        {
                  
            playerAnimation.FallAnimation();
        }
                
       
    }

    private void HandleObstacleCollision()
    {
        playerAnimation.StumbleAnimation();
       
    }

   
}


