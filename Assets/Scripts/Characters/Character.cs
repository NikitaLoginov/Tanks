using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] [Range(1f,.1f)] private float defense = .5f;
    [SerializeField] private HealthBar healthBar;
    private float _currentHealth;

    private void OnEnable()
    {
        _currentHealth = maxHealth;
        healthBar.SetMaxHealthSlider(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount * defense;
        healthBar.SetHealthSlider(_currentHealth);
        
        if(_currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
