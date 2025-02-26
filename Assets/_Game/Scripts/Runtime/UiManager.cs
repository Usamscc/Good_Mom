
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
  public static UiManager instance;
  public event Action PauseGame;
  
  [Header("PopUps")]
  [SerializeField] private GameObject settingPopUp;
  [SerializeField] private GameObject failedScreenPopUp;
  [SerializeField] private GameObject topBar,sliderCanvas;
  

  [Header("Text UI")]
  [SerializeField] private Text coinText;
  
  [Header("Slider UI")]
  [SerializeField] private Slider beautySlider;
  [SerializeField] private Slider levelSlider;
  [SerializeField] private GameObject swipeSlider;
  
  private float fullDistance;
    private bool isMusicOn = true;
  
  
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    
    }
  }


  public void FailedScreenPopUp()
  {
    Invoke(nameof(CallFailedScreenPopUp), 4.5f);
  }

  public void CallFailedScreenPopUp()
  {
        AudioManager.instance.Play("Game End");
        failedScreenPopUp.SetActive(true);
    topBar.SetActive(false);
    sliderCanvas.SetActive(false);
  }

  public void DeactivateTutorial()
  {
    swipeSlider.gameObject.SetActive(false);
  }
  
  public void LevelSliderSetter(float levelSliderValue)
  {
    float progressive=Mathf.InverseLerp(fullDistance,0f,levelSliderValue);
    levelSlider.value = progressive;
  }

  public void SetFullDistance(float distance)
  {
    fullDistance = distance; 
   
  }
  
  public void SetCoinText(string text)
  {
    coinText.text = text;
  }
  
  public void BeautySliderSetter(float num)
  {
    beautySlider.value = num;
  }

  public void SettingBtnClick()
  {
        AudioManager.instance.Play("SettingOn");
        settingPopUp.SetActive(true);
    Time.timeScale = 0;
    PauseGame?.Invoke();
  }

public void MusicOffBtnClick()
    {

        AudioManager.instance.Play("SettingOn");
        isMusicOn =!isMusicOn;
        if (isMusicOn)
        {
            AudioManager.instance.Play("Theme");

        }
        else
        {
            AudioManager.instance.Pause("Theme");

        }
       
    }

  public void RestartBtnClick()
  {
        AudioManager.instance.Play("SettingOn");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1;
  }

  public void ExitBtnClick()
  {
        AudioManager.instance.Play("SettingOff");
        settingPopUp.SetActive(false);
    Time.timeScale = 1;
  }
}
