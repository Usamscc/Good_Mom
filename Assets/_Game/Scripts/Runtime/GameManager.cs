using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cameraParent;
    [SerializeField] private int beautyFactor;
    public static GameManager instance;
    
    private bool isGameEnded=false;
    
    public static int coinsCount=0;
    public static int beautyScore = 100;
    
  
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    public void CoinCollected()
    {
        coinsCount++;
    }

    public void BeautyScore(int score)
    {
        beautyScore+=score;

        if (beautyScore < beautyFactor)
        {

        }
        else
        {

        }
    }
    public void GameEnded()
    {
        FollowPlayer cameraFollow=cameraParent.GetComponent<FollowPlayer>();
        RotateItems cameraRotate=cameraParent.GetComponent<RotateItems>();

        cameraFollow.enabled = false;
        cameraRotate.enabled = true;
        isGameEnded = true;
        
        print("Game Over " + isGameEnded);
    }
    public bool GetGameOver()
    {
        return !isGameEnded;
    }

    public void RotateCamera()
    {

    }


    public void PrintGameOver()
    {
        print("Coins Collected "+ coinsCount);
        print("Beauty Score "+ beautyScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
