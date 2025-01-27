using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("GameObjects")]
    [SerializeField] private GameObject cameraParent;
    
    [Space]
    [Header("Variables")]
    [SerializeField] private int beautyFactor;
    [SerializeField] private int beautyScore = 100;
    
    [HideInInspector]
    public bool beautyPositive = true;
    
    private bool isGameEnded=false;
    private int coinsCount=0;
    
  
    
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
        beautyPositive = beautyScore >= beautyFactor;
        
    }
    public void GameEnded()
    {
        RotateItems cameraRotate=cameraParent.GetComponent<RotateItems>();
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
