
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
  public static UiManager instance;
  [SerializeField] private GameObject settingPopUp;
  

  public event Action PauseGame;


  private void Start()
  {
    if (instance == null)
    {
      instance = this;
    }
  }

  public void SettingBtnClick()
  {
    settingPopUp.SetActive(true);
    Time.timeScale = 0;
    PauseGame?.Invoke();
  }

  public void RestartBtnClick()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1;
  }

  public void ExitBtnClick()
  {
    settingPopUp.SetActive(false);
    Time.timeScale = 1;
  }
}
