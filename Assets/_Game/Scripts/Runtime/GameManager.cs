
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("GameObjects")]
    [SerializeField] private GameObject cameraParent;
    [SerializeField] private Text coinText; //,beautyText
    
    [SerializeField] private Slider beautySlider;
    [SerializeField] private Slider levelSlider;
    [SerializeField] private GameObject Male, female;
    
    [Space]
    [Header("Variables")]
    [SerializeField] private int beautyFactor;
    [SerializeField] private int beautyScore = 100;
    
    [HideInInspector]
    public bool beautyPositive = true;
    
    private bool isGameEnded=false;
    private bool isGamePaused = false;

    
    private string filePath;
    private float fullDistance;
    [SerializeField] private PlayerData playerData;
    
    


   


    void Start()
    {
       
        if (instance == null)
        {
            instance = this;
        }
        filePath = Application.dataPath + "/_Game/Data/gamedata.json";
        if (System.IO.File.Exists(filePath))
        {
            LoadData();
        }

//        UiManager.instance.PauseGame += PauseGame;
        beautySlider.value = playerData.beautyScore/100f;
        
        coinText.text = playerData.coins.ToString();
        
        fullDistance= Vector3.Distance(female.transform.position, Male.transform.position);
        // beautyText.text = playerData.beautyScore.ToString();

    }

    private void Update()
    {
        float newDistance = Vector3.Distance(female.transform.position, Male.transform.position);
        float progressive=Mathf.InverseLerp(fullDistance,0f,newDistance);
        levelSlider.value = progressive;
    }

    public void CoinCollected()
    {
        
        playerData.coins +=1 ;
        coinText.text = playerData.coins.ToString();
    }

    public void BeautyScore(int score)
    {
      
        beautyScore+=score;
        playerData.beautyScore +=score;
         beautySlider.value = playerData.beautyScore/100f;
        // beautyText.text = playerData.beautyScore.ToString();
        beautyPositive = beautyScore >= beautyFactor;
        
    }
    public void GameEnded()
    {
        RotateItems cameraRotate=cameraParent.GetComponent<RotateItems>();
        cameraRotate.enabled = true;
        isGameEnded = true;
        
        print("Game Over " + isGameEnded);
    }

    public void PauseGame()
    {
        isGamePaused = true;
        print("Game Paused");
    }
    public bool GetGameOver()
    {
        return !isGameEnded;
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



