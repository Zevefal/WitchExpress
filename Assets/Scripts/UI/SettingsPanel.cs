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

	[SerializeField] private SaveLoadManager _saveLoadManager;
	[SerializeField] private AudioMixerGroup _mixerGroup;
	[SerializeField] private Slider _volumeSlider;
	[SerializeField] private Toggle _musicToggle;
	[SerializeField] private Toggle _soundToggle;

	public float Volume => _volumeSlider.value;
	public bool MusicToggle => _musicToggle.isOn;
	public bool SoundToggle => _soundToggle.isOn;

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

		_saveLoadManager.Save();
	}

	public void ToggleSound(bool enabled)
	{
		if (enabled)
		{
			_mixerGroup.audioMixer.SetFloat(MasterVolume, 0f);
			_soundToggle.isOn = true;
		}
		else
		{
			_mixerGroup.audioMixer.SetFloat(MasterVolume, -80f);
			_soundToggle.isOn = false;
		}
		_saveLoadManager.Save();
	}

	public void ChangeVolume(float volume)
	{
		AudioListener.volume = volume;
		_saveLoadManager.Save();
	}

	public void SetPlayerVolumeSettings(float savedVolume, bool savedToggle, bool savedSound)
	{
		SetSliderValue(savedVolume);
		// ToggleMusic(savedToggle);
		// ToggleSound(savedSound);
		_musicToggle.isOn = savedToggle;
		_soundToggle.isOn = savedSound;
	}

	private void SetSliderValue(float value)
	{
		_volumeSlider.value = value;
	}
}
