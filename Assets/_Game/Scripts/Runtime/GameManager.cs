using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cameraParent;
    [SerializeField] private int beautyFactor;
    [SerializeField] private int beautyScore = 100;
    
    public static GameManager instance;
    
    private bool isGameEnded=false;
    private int coinsCount=0;
    
    [HideInInspector]
    public bool beautyPositive = true;
    
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
            beautyPositive = false;
        }
        else
        {
            beautyPositive = true;

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
  
    public void PrintGameOver()
    {
        print("Coins Collected "+ coinsCount);
        print("Beauty Score "+ beautyScore);
    }

}
