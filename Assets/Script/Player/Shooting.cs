using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _fireball;
    private PlayerMovement _player;
    private MoveEnemy _enemy;
    private int _currentPlayer;
    private int _currentEnemy;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _enemy = FindObjectOfType<MoveEnemy>();
    }

    void Update()
    {
        if (Base.Death == false)
        {
            if (Base.FireBall == true && Base.Go == false)
            {
                _currentEnemy = _enemy.currentFree;
                if (_currentEnemy == 0)
                {
                    _currentEnemy = 2;
                }
                else if (_currentEnemy == 2)
                {
                    _currentEnemy = 0;
                }
                _currentPlayer = _player.currentPosition;
                if (_currentPlayer == _currentEnemy)
                {
                    Instantiate(_fireball, transform.position, Quaternion.identity);
                    Base.FireBall = false;
                }
                else
                {
                    Base.FireBall = false;
                }
            }
        }
    }
}
