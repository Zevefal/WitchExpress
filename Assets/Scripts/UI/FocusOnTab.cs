using Agava.WebUtility;
using UnityEngine;
using UnityEngine.Audio;

public class FocusOnTab : MonoBehaviour
{
	private const string MasterVolume = "MasterVolume";

	[SerializeField] private ShowAdvertisement _showVideoAd;
	[SerializeField] private SaveLoadManager _saveLoadManager;
	[SerializeField] private SceneHandler _sceneHendler;
	[SerializeField] private AudioMixerGroup _mixerGroup;

	private void OnEnable()
	{
		_showVideoAd.IsVideoOpen += OnInBackgroundChangeApp;
		_showVideoAd.IsVideoOpen += OnInBackgroundChangeWeb;
		Application.focusChanged += OnInBackgroundChangeApp;
		WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
	}

	private void OnDisable()
	{
		Application.focusChanged -= OnInBackgroundChangeApp;
		WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
	}

	private void OnInBackgroundChangeApp(bool inApp)
	{
		MuteAudio(!inApp);
		PauseGame(!inApp);
	}

	private void OnInBackgroundChangeWeb(bool isBackground)
	{
		MuteAudio(isBackground);
		PauseGame(isBackground);
	}

	private void MuteAudio(bool value)
	{
		//_mixerGroup.audioMixer.SetFloat(MasterVolume, value ? -80 : _saveLoadManager.PlayerInfo.Volume);

		AudioListener.volume = value ? 0 : _saveLoadManager.PlayerInfo.Volume;
	}

	private void PauseGame(bool value)
	{
		if(value == false)
		{
			_sceneHendler.Resume();
		}
		else
		{
			_sceneHendler.SetPause();
		}
	}
}
