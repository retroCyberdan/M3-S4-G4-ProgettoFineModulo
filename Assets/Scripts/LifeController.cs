using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _maxHP = 10;
    private int _currentHP;

    // Start is called before the first frame update
    void Start()
    {
        _currentHP = _maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0) IsDead();
    }

    public void IsDead()
    {
        Destroy(gameObject);
    }
}
