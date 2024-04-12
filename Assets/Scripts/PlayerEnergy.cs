using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;


public class PlayerEnergy : MonoBehaviour
{
    private const string EnergyKey = "Energy";

    [SerializeField] private TMP_Text _energyTimerText;

    [SerializeField]private int _energy;
    private int _defaultEnergy = 50;
    private int _maxEnergy = 50;
    private float _currentTime = 60f;
    private float _waitTime = 60f;
    private int _energyRestoreCount = 1;
    private bool _initialized = false;

    public UnityAction<int,int> EnergyChanged;
    public int Energy => _energy;
    public int MaxEnergy => _maxEnergy;

    private void Start()
    {
        //if(_initialized == false)
        //{
        //    _energy = _defaultEnergy;
        //}
        //_maxEnergy = _defaultEnergy;
        //_energy = SaveSystem.Instance.PlayerData.Energy;

        //if (PlayerPrefs.HasKey(EnergyKey))
        //{
        //    _energy = SaveSystem.Instance.PlayerData.Energy;
        //    _maxEnergy = _defaultEnergy;
        //    PlayerPrefs.SetInt(EnergyKey, _energy);
        //}
        //else
        //{
        //    _maxEnergy = _defaultEnergy;
        //    _energy = _maxEnergy;
        //    PlayerPrefs.SetInt(EnergyKey, _energy);
        //}
       // _energy = SaveLoadManager.PlayerInfo.Energy;
        _maxEnergy = _defaultEnergy;
        EnergyChanged?.Invoke(_energy, _maxEnergy);
        StartCoroutine(StaminaTimer());
    }

    public bool TakeEnergy(int countOfEnergy)
    {
        if(countOfEnergy <= _energy)
        {
            _energy -= countOfEnergy;
            EnergyChanged?.Invoke(_energy,_maxEnergy);
            PlayerPrefs.SetInt(EnergyKey, _energy);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddEnergy(int count)
    {
        if(count >= 0)
        {
           // _maxEnergy = _defaultEnergy;
            _energy += count;
        }

        if (_energy >= _maxEnergy)
        {
            //_maxEnergy = _defaultEnergy;
            _energy = _maxEnergy;
        }

        EnergyChanged?.Invoke(_energy, _maxEnergy);
        PlayerPrefs.SetInt(EnergyKey, _energy);
    }

    private IEnumerator StaminaTimer()
    {
        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
            {
                _currentTime = _waitTime;
               AddEnergy(_energyRestoreCount);
            }

            yield return null;
            RefreshTimeText();
        }
    }

    private void RefreshTimeText()
    {
        float minutes = Mathf.FloorToInt(_currentTime / 60);
        float seconds = Mathf.FloorToInt(_currentTime % 60);

        //_energyTimerText.text = minutes + ":" + seconds;
    }
}
