using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSlider : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveX(-1,2f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

            });
    }
}
