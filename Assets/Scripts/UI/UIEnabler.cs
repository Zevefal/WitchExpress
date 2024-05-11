using UnityEngine;
using Agava.WebUtility;

public class UIEnabler : MonoBehaviour
{
	[SerializeField] private GameObject[] _interfaces;
	[SerializeField] private GameObject _restartButton;
	[SerializeField] private GameObject _jostick;
	[SerializeField] private SceneHandler _sceneHandler;

	private void OnEnable()
	{
		_sceneHandler.IsGameStarted += SetObjectsActivity;
	}

	private void OnDisable()
	{
		_sceneHandler.IsGameStarted -= SetObjectsActivity;
	}

	private void SetObjectsActivity()
	{
		if (Device.IsMobile)
		{
			_jostick.SetActive(true);
		}

		foreach (GameObject ui in _interfaces)
		{
			if (ui.activeSelf == true)
			{
				ui.SetActive(false);
			}
		}
		
		_restartButton.SetActive(true);
	}
}
