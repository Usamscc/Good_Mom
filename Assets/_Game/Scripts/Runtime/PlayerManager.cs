
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private PlayerMove playerMovement;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private MaleCollision malePosiiton;
    [SerializeField] private ParticleSystem confettiPS; 
    
    [SerializeField] private float lerpingStat;
    
    [Space]
    [Header("Game Variables")]
    
    
    private bool gameFinishedCrossed = false;
    private Vector3 move;
    private float movingSpeed = 1f;
    private float animationSpeed = .9f;
    private Vector3 dist;
   
   //Vector3(0.310000002,0,-186.229996)

    private void Update()
    {
        if (GameManager.instance.GetGameOver())
        {
            MovePlayer();
          
        }else{
            
            confettiPS.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        

    }

   

    private void MovePlayer()
    {
        //check if race line crossed and restrict user to move horizontally 
        if (gameFinishedCrossed)
        {
            dist = (malePosiiton.transform.position - transform.position).normalized;
            playerMovement.PlayerMovementTowards(dist);
        }
        else
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, movingSpeed);
            playerMovement.PlayerMovement(move);
        }

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


