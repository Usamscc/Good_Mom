using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
 
   [SerializeField] private Slider slider; 
   [SerializeField] private  float targetValue = 1f;
   [SerializeField] private  float duration = 100f;

   void Start()
   {
      slider.DOValue(targetValue, duration).SetEase(Ease.InOutQuad)
         .OnComplete(() =>
         {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         });
   }

   
}
