using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [SerializeField] private string _name;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioMixerGroup _output;
    [Range(0f, 1f)]
    [SerializeField] private float _volume = 1f;
    [SerializeField] private bool _playOnAwake = false;
    [SerializeField] private bool _loop = false;
    [SerializeField] private AudioSource _audioSource;

    public string Name => _name;
    public AudioSource Source => _audioSource;

    public void SetAudioSource(AudioSource audioSource)
    {
        _audioSource = audioSource;

        InitializeSound();
    }

    private void InitializeSound()
    {
        _audioSource.clip = _clip;
        _audioSource.volume = _volume;
        _audioSource.playOnAwake = _playOnAwake;
        _audioSource.loop = _loop;
        _audioSource.outputAudioMixerGroup = _output;
    }
}
