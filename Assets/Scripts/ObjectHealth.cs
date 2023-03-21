using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour, IDamageable
{
    [SerializeField, Range(100, 1000)]
    private int _maxHealth = 200;
    private int _currentHealth;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    protected int GetCurrentGealth()
    {
        return _currentHealth;
    }

    void IDamageable.TakeDamage(int value)
    {
        _currentHealth -= value;
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
