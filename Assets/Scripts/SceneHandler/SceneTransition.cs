using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
	[SerializeField] private GameObject LoadingScreen;
	private AsyncOperation _loadingSceneOperation;

	public void LoadScene(string sceneName)
	{
		LoadingScreen.SetActive(true);
		StartCoroutine(LoadSceneAsync(sceneName));
	}

	private IEnumerator LoadSceneAsync(string sceneName)
	{
		_loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);

		while (!_loadingSceneOperation.isDone)
		{
			yield return null;
		}
	}
}