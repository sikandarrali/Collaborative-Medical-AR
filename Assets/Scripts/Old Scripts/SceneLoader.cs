using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text loadingPercentage;

    public Scene sceneToLoad;

    // public int sceneIndex = 0;

    void Start()
    {
        StartCoroutine(loadLoader());
    }

    IEnumerator loadLoader()
    {
        yield return new WaitForSeconds(4);
        StartCoroutine(LoadAsynchoronously());
    }

    IEnumerator LoadAsynchoronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("sceneToLoad");
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            loadingPercentage.text = progress * 100f + "%";
            yield return null;
        }
    }

}
