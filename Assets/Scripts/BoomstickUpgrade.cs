using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class BoomstickUpgrade : MonoBehaviour
{
    private const string HealthPowerUp = "Health";

    [SerializeField] private string _upgradeName;
    [SerializeField] private int _initialCost;
    [SerializeField] private float _progression;
    [SerializeField] private int _maxPowerCount;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private TMP_Text _powerUpButtonNameText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Wallet _wallet;

    private int _powerCount = 1;
    private int _currentCost;
    private int _addPowerCount = 1;

    private void OnEnable()
    {
        _powerUpButtonNameText.text = ($"Player {_upgradeName} + {_addPowerCount}");

        SetCost();
    }

    public void Upgrade()
    {
        _powerCount = PlayerPrefs.GetInt(_upgradeName);

        if (_powerCount < _maxPowerCount && _wallet.Money >= _currentCost)
        {
            PlayerPrefs.SetInt(_upgradeName, _powerCount + _addPowerCount);

            if (_upgradeName == HealthPowerUp)
            {
                _playerHealth.PowerUpHealth(_addPowerCount);
                _wallet.TakeMoney(_currentCost);
            }
            else
            {
                _characterMovement.PowerUp(_upgradeName, _addPowerCount);
                _wallet.TakeMoney(_currentCost);
            }

            SetCost();
        }
    }

    private void SetCost()
    {
        if (PlayerPrefs.HasKey(_upgradeName))
        {
            _powerCount = PlayerPrefs.GetInt(_upgradeName);
            _currentCost = Mathf.RoundToInt(_initialCost * Mathf.Pow(_progression, _powerCount - 1));
            _costText.text = _currentCost.ToString();
        }
        else
        {
            PlayerPrefs.SetInt(_upgradeName, _powerCount);
            SetCost();
        }
    }
}
