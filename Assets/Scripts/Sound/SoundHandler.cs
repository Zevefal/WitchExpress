using System;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
	private const string MainSound = "Main";

	public static SoundHandler Instance;

	[SerializeField] private Sound[] _sounds;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}

		foreach (Sound sound in _sounds)
		{
			sound.SetAudioSource(gameObject.AddComponent<AudioSource>());
		}
	}

	private void Start()
	{
		PlaySound(MainSound);
	}

	public void PlaySound(string name)
	{
		Sound sound = Array.Find(_sounds, sound => sound.Name == name);

		if(sound == null)
		{
			Debug.Log("Sound not found");
		}
		else
		{
			sound.Source.Play();
		}
	}
}

