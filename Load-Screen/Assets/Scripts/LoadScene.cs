using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public Slider slider;
    public GameObject parentSlider;

    public void LoadLevel(int IndexLevel)
    {
        StartCoroutine(AsyncLoadLevel(IndexLevel));
    }

    IEnumerator AsyncLoadLevel(int IndexLevel)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(IndexLevel);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
        
    }
}
