using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	private const string UiSound = "Ui";

	[SerializeField] private PlayerEnergy _energy;
	[SerializeField] private Transform _startPosition;
	[SerializeField] private GameObject[] _uiObjects;
	[SerializeField] private SaveLoadManager _saveLoadManager;
	[SerializeField] private SceneTransition _sceneTransition;

	private bool _isStarted = false;
	private int _energyCost = 5;

	public static event UnityAction IsRestarted;

	public int EnergyCost => _energyCost;
	public bool IsStarted => _isStarted;

	private void Awake()
	{
		OnCallGameReadyButtonClick();

		Time.timeScale = 0;
	}

	public void StartGame()
	{
		//if (_energy.TakeEnergy(_energyCost))
		//{
		Time.timeScale = 1;
		_isStarted = true;
		//}
	}

	public void RestartGame()
	{
		SoundHandler.Instance.PlaySound(UiSound);
		//_saveLoadManager.LoadGame();
		_sceneTransition.LoadScene(SceneManager.GetActiveScene().name);
		IsRestarted?.Invoke();
		_energy.gameObject.transform.position = _startPosition.position;
		_energy.gameObject.SetActive(true);
	}

	public void SetPause()
	{
		SoundHandler.Instance.PlaySound(UiSound);
		Time.timeScale = 0;
	}

	public void Resume()
	{
		SoundHandler.Instance.PlaySound(UiSound);

		if (_isStarted)
		{
			Time.timeScale = 1;
		}
	}

	public void ExitGame()
	{
		SoundHandler.Instance.PlaySound(UiSound);
		//SaveSystem.Instance.Save();
		Application.Quit();
	}

	public void OnCallGameReadyButtonClick()
	{
		YandexGamesSdk.GameReady();
	}
}
