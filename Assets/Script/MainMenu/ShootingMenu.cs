using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMenu : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _fireball;
    private SantaMove _player;
    private MoveEnemy _enemy;
    private Animator _anima;
    private int _currentPlayer;
    private int _currentEnemy;

    private void Awake()
    {
        _player = FindObjectOfType<SantaMove>();
        _enemy = FindObjectOfType<MoveEnemy>();
        _anima = GetComponent<Animator>();
    }

    void Update()
    {
        if (Base.FireBall == true)
        {
            _currentEnemy = _enemy.currentFree;
            _currentPlayer = _player.currentFree;
            if (_currentPlayer == _currentEnemy)
            {
                _anima.SetBool("Fire", true);
                Base.FireBall = false;
            }
            else
            {
                Base.FireBall = false;
            }
        }
    }

    /// <summary>
    /// Реализация выстрела
    /// </summary>
    public void Fire()
    {
        Instantiate(_fireball, _point.position, Quaternion.identity);
        _anima.SetBool("Fire", false);
    }
}
