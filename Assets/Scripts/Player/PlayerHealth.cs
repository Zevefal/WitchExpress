using UnityEngine;
using UnityEngine.Events;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private int _defaultMaxHealth;

	private int _health;
	private int _maxHealth;
	private bool _isShielded;

	public int Health => _maxHealth;

	public event UnityAction<int, int> HealthChanged;
	public event UnityAction IsDead;

	public void TakeDamage(int damage)
	{
		if (!_isShielded)
		{
			_health -= damage;
		}

		HealthChanged?.Invoke(_health, _maxHealth);

		if (_health <= 0)
		{
			_health = 0;
			IsDead?.Invoke();
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

	public void DebaffPlayerHealth(int count)
	{
		int debaffedHealth = (int)((float)_maxHealth * count / 100f);
		_health = debaffedHealth;
		HealthChanged?.Invoke(_health, debaffedHealth);
	}

	public void PowerUpHealth(int count)
	{
		_maxHealth += count;

		if (_health < _maxHealth)
			_health = _maxHealth;

		HealthChanged?.Invoke(_health, _maxHealth);
	}

	public void SetPlayerHealth(int savedHealth)
	{
		if (savedHealth <= _defaultMaxHealth)
		{
			_maxHealth = _defaultMaxHealth;
		}
		else
		{
			_maxHealth = savedHealth;
		}

		_health = _maxHealth;
		HealthChanged?.Invoke(_health, _maxHealth);
	}
}
