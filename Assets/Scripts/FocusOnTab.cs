using Agava.WebUtility;
using UnityEngine;
using UnityEngine.Audio;

public class FocusOnTab : MonoBehaviour
{
	private const string MasterVolume = "MasterVolume";

	[SerializeField] private SaveLoadManager _saveLoadManager;
	[SerializeField] private SceneHandler _sceneHendler;
	[SerializeField] private AudioMixerGroup _mixerGroup;

	private void OnEnable()
	{
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
		_mixerGroup.audioMixer.SetFloat(MasterVolume, value ? -80 : _saveLoadManager.PlayerInfo.Volume);
	}

	private void PauseGame(bool value)
	{
		//Time.timeScale = value ? 0 : 1;
		// if(value == false && Time.timeScale == 0){
		//     Time.timeScale = 0;
		// }else if(value == false && Time.timeScale == 1){
		//     Time.timeScale = 1;
		// }
		
		// if(_sceneHendler.IsStarted == false && value == true)
		// {
		//     Time.timeScale = 0;
		// }else if(_sceneHendler.IsStarted == true && value == true)
		// {
		//     Time.timeScale = 0;
		// }else if(_sceneHendler.IsStarted == false && value == false)
		// {
		//     Time.timeScale = 0;
		// }else 
		if(_sceneHendler.IsStarted == true && value == false)
		{
			Time.timeScale = 1;
		}
		else
		{
			Time.timeScale = 0;
		}
	}
}
