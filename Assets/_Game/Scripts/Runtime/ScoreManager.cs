using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   
    
    public static ScoreManager instance;
    
    
    


    private void Start()
    {
        if(instance == null)
            instance = this;
        
        // playerData = new PlayerData();
    }
}
