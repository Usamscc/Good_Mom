
using OpenCover.Framework.Model;
using UnityEngine;
using UnityEngine.UI;
using File = UnityEngine.Windows.File;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("GameObjects")]
    [SerializeField] private GameObject cameraParent;
    [SerializeField] private Text coinText,beautyText;
    
    [Space]
    [Header("Variables")]
    [SerializeField] private int beautyFactor;
    [SerializeField] private int beautyScore = 100;
    
    [HideInInspector]
    public bool beautyPositive = true;
    
    private bool isGameEnded=false;
    private int coinsCount=0;
    [SerializeField] private PlayerData playerData;
    private string filePath;
    
  
    
    void Start()
    {
        playerData = new PlayerData();
        if (instance == null)
        {
            instance = this;
        }
        filePath = Application.dataPath + "/_Game/Data/gamedata.json";
        if (File.Exists(filePath))
        {
            LoadData();
        }

        coinText.text = playerData.coins.ToString();
        beautyText.text = playerData.beautyScore.ToString();

    }

    public void CoinCollected()
    {
       
        coinsCount++;
        playerData.coins +=1 ;
        coinText.text = playerData.coins.ToString();
    }

    public void BeautyScore(int score)
    {
      
        beautyScore+=score;
        playerData.beautyScore +=score;
        beautyText.text = playerData.beautyScore.ToString();
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

    public void SaveData()
    {
        string json = JsonUtility.ToJson(playerData);
        print(json);
        System.IO.File.WriteAllText(filePath, json);
       
    }

    private void LoadData()
    {
        string json = System.IO.File.ReadAllText(filePath);
        // string json = PlayerPrefs.GetString("SaveData");
        playerData = JsonUtility.FromJson<PlayerData>(json);
        
        print("From load data "+playerData.coins);
        print("From load data "+playerData.beautyScore);
    }

}

[System.Serializable]
public class PlayerData
{
    public int coins;
    public int beautyScore;

    public PlayerData()
    {
        coins = 0;
        beautyScore = 100;
    }
    // public int CoinsCount
    // {
    //     get => coins;
    //     set => coins = value;
    // }
    //
    // public int BeautyScore
    // {
    //     get => beautyScore;
    //     set => beautyScore = value;
    // }
}

