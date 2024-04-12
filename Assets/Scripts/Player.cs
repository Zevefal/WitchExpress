using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;
    private bool _isShielded;

    public UnityAction<int,int> HealthChanged;

    public void TakeDamage(int damage)
    {
        if(!_isShielded)
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
        _health+= healCount;

        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }

        HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void SetShield(bool isShielded)
    {
        _isShielded = isShielded;
    }

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health, _maxHealth);
    }
}
