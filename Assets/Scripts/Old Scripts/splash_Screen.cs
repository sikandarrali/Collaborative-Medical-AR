using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class splash_Screen : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider slider;
	public Text loadingPercentage;

	// public int sceneIndex = 0;

	void Start() {
		StartCoroutine(loadLoader());	
	}

	IEnumerator loadLoader()
	{
		yield return new WaitForSeconds(4);
		StartCoroutine(LoadAsynchoronously());
	}

	IEnumerator LoadAsynchoronously()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(1);
		loadingScreen.SetActive(true);
		while(!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress/0.9f);
			slider.value = progress;
			loadingPercentage.text = progress * 100f + "%";
			yield return null;
		}
	}

}
