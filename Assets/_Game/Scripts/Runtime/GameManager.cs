using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private bool goalReached=false;
    
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
        beautyScore-=score;
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
