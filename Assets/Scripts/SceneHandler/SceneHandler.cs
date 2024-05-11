using System;
using Agava.YandexGames;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	[SerializeField] private JoystickMovement _characterMovement;
	[SerializeField] private GameObject _settingsPanel;
	[SerializeField] private SaveLoadManager _saveLoadManager;
	[SerializeField] private SceneTransition _sceneTransition;
	[SerializeField] private ShowAdvertisement _showAdvertisement;

	private bool _isStarted = false;
	private FinishWallInterraction _finishWallInterraction;

	public event Action IsGameStarted;

	private void OnEnable()
	{
		_showAdvertisement.PlayerRewarded += RestartGame;
	}
	
	private void OnDisable()
	{
		_showAdvertisement.PlayerRewarded -= RestartGame;
	}
	
	private void Awake()
	{
		OnCallGameReadyButtonClick();
		SetPause();
	}

	public void StartGame()
	{
		_finishWallInterraction = FindObjectOfType<FinishWallInterraction>();
		_saveLoadManager.Save();
		_isStarted = true;
		IsGameStarted?.Invoke();
		Resume();
	}
	public void RestartGame()
	{
		_saveLoadManager.Save();
		_sceneTransition.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void SetPause()
	{
		Time.timeScale = 0;
		_characterMovement.enabled = false;
	}

	public void Resume()
	{
		if (_isStarted == true && _settingsPanel.activeSelf == false && _finishWallInterraction.IsFinished == false)
		{
			Time.timeScale = 1;
			_characterMovement.enabled = true;
		}
	}

	public void OnCallGameReadyButtonClick()
	{
		YandexGamesSdk.GameReady();
	}
}
