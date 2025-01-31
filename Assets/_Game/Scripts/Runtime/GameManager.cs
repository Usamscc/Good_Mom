using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("GameObjects")]
    [SerializeField] private GameObject cameraParent;
    
    // Vector3(0.310000002,-0.061999999,-187.369995)
    
    [Space]
    [Header("Variables")]
    [SerializeField] private int beautyFactor;
    [SerializeField] private int beautyScore = 100;
    [SerializeField] private PlayerData playerData;
    
    [HideInInspector] public bool beautyPositive = true;
    [HideInInspector] public bool isGameStarted = false;
    
    private bool isGameEnded=false;
    private bool isGamePaused = false;
    
    
    private string filePath;
  

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        LoadData();
    }


    public void CoinCollected()
    {
        playerData.coins +=1 ;
        UiManager.instance.SetCoinText( playerData.coins.ToString());
    }

    public void BeautyScore(int score)
    {
        beautyScore+=score;
        playerData.beautyScore +=score;
        if (playerData.beautyScore < 0)
        {
            playerData.beautyScore = 0;
        }
        UiManager.instance.BeautySliderSetter(playerData.beautyScore/100f); 
        // beautyText.text = playerData.beautyScore.ToString();
        beautyPositive =  playerData.beautyScore >= beautyFactor;
        
    }
    public void GameEnded()
    {
        RotateItems cameraRotate = cameraParent.GetComponent<RotateItems>();
        isGameEnded = true;

        if (beautyPositive)
        {
            cameraRotate.enabled = true;
           
            print("sharam ker");
        }
        else
        {
            UiManager.instance.FailedScreenPopUp();
        }
        
        // if (beautyPositive)
        // {
        //     RotateItems cameraRotate = cameraParent.GetComponent<RotateItems>();
        //     cameraRotate.enabled = true;
        //     isGameEnded = true;
        // }
        // else
        // {
        //     UiManager.instance.FailedScreenPopUp();
        // }
        //
        
    }

    public void StartGame()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            isGameStarted = true;
        }

        if (isGameStarted)
        {
            UiManager.instance.DeactivateTutorial();
        }
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
        filePath = Application.persistentDataPath + "/gamedata.json";
        if (!System.IO.File.Exists(filePath))
        {
            return;
        }
        string json = System.IO.File.ReadAllText(filePath);
        playerData = JsonUtility.FromJson<PlayerData>(json);
        
        UiManager.instance.BeautySliderSetter(playerData.beautyScore/100f);
        UiManager.instance.SetCoinText( playerData.coins.ToString());
        
        // string json = PlayerPrefs.GetString("SaveData");
        print("From load data "+playerData.coins);
        print("From load data "+playerData.beautyScore);
    }

    public void FullLevelDistance(float distance)
    {
        UiManager.instance.SetFullDistance(distance);
        
    }
    public void RemainingLevelDistance(Transform female, Transform male)
    {
        float newDistance = Vector3.Distance(female.position, male.position);
       
        UiManager.instance.LevelSliderSetter(newDistance);
        
    }

}



