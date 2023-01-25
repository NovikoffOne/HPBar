using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private Animator _animator;
    private bool _isLife;
    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _isLife = true;

        _animator = GetComponent<Animator>();

        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_isLife == true)
        {
            _currentHealth -= damage;

            HealthChanged?.Invoke(_currentHealth, _maxHealth);
            
            _animator.Play("Hurt");
            
            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Heal(int health)
    {
        if (_isLife == true)
        {
            _currentHealth += health;

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }

            HealthChanged?.Invoke(_currentHealth, _maxHealth);

            _animator.Play("Heal");
        }
    }

    private void Die()
    {
        _animator.Play("Die");

        _isLife = false;
    }
}
