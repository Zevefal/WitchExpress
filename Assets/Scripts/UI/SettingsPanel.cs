using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
	private const string MusicVolume = "MusicVolume";
	private const string MasterVolume = "MasterVolume";
	private const string VolumePrefs = "Volume";
	private const string SliderValuePrefs = "SliderVolume";
	private const string MusicPrefs = "Music";

	[SerializeField] private AudioMixerGroup _mixerGroup;
	[SerializeField] private Slider _volumeSlider;
	[SerializeField] private Toggle _musicToggle;

	private float _sliderValue;

	public float Volume => _volumeSlider.value;
	public bool MusicToggle => _musicToggle.isOn;
	
	public void ToggleMusic(bool enabled)
	{
		if (enabled)
		{
			_mixerGroup.audioMixer.SetFloat(MusicVolume, 0f);
			_musicToggle.isOn = true;
		}
		else
		{
			_mixerGroup.audioMixer.SetFloat(MusicVolume, -80f);
			_musicToggle.isOn = false;
		}
	}

	public void ChangeVolume(float volume)
	{
		//_mixerGroup.audioMixer.SetFloat(MasterVolume,/*Mathf.Lerp(-80,0,volume)*/Mathf.Log10(volume)*20);
		AudioListener.volume = volume;
		//_sliderValue = volume;
		//PlayerPrefs.SetFloat(VolumePrefs, volume);
		//PlayerPrefs.SetFloat(SliderValuePrefs, _volumeSlider.value);
	}

	public void SetPlayerVolumeSettings(float savedVolume, bool savedToggle)
	{
		//if(PlayerPrefs.HasKey(VolumePrefs))
		//{
		//    ChangeVolume(PlayerPrefs.GetFloat(VolumePrefs));
		//    _volumeSlider.value = PlayerPrefs.GetFloat(VolumePrefs);
		//}

		//if(PlayerPrefs.HasKey(MusicPrefs))
		//{
		//    ToggleMusic(Convert.ToBoolean(PlayerPrefs.GetInt(MusicPrefs)));
		//    _musicToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt(MusicPrefs));
		//}

		//if (PlayerPrefs.HasKey(VolumePrefs))
		//{
		//    ChangeVolume(SaveSystem.Instance.PlayerData.Volume);
		//    //_volumeSlider.value = SaveSystem.Instance.PlayerData.SliderValue;
		//    _volumeSlider.value = SaveSystem.Instance.PlayerData.Volume;
		//}

		//if (PlayerPrefs.HasKey(MusicPrefs))
		//{
		//    ToggleMusic(SaveSystem.Instance.PlayerData.Music);
		//    _musicToggle.isOn = SaveSystem.Instance.PlayerData.Music;
		//}
	   // ChangeVolume(savedVolume);
		SetSliderValue(savedVolume);
		ToggleMusic(savedToggle);
	}

	private void SetSliderValue(float value)
	{
		_volumeSlider.value = value;
		//ChangeVolume(value);
	}
}
