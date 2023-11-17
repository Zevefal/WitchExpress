using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{
    private const string HealthPowerUp = "Health";

    [SerializeField] private int _defaultMaxHealth;

    private int _health;
    private int _maxHealth;
    private bool _isShielded;

    public UnityAction<int, int> HealthChanged;

    private void Start()
    {
        if (PlayerPrefs.HasKey(HealthPowerUp))
        {
            _defaultMaxHealth += PlayerPrefs.GetInt(HealthPowerUp);
            _maxHealth = _defaultMaxHealth;
        }
        else
        {
            _maxHealth = _defaultMaxHealth;
        }

        _health = _maxHealth;
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!_isShielded)
        {
            _health -= damage;
        }

        HealthChanged?.Invoke(_health, _maxHealth);

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int healCount)
    {
        _health += healCount;

        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }

        HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void SetShieldOn()
    {
        _isShielded = true;
    }

    public void SetShieldOff()
    {
        _isShielded = false;
    }

    public void SetPlayerHealth(int count)
    {
        _maxHealth = (int)((float)_maxHealth * count / 100f);
        _health = _maxHealth;
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void PowerUpHealth(int count)
    {
        _maxHealth += count;
        HealthChanged?.Invoke(_health, _maxHealth);
    }
}
