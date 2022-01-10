using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Monocache
{
    //[SerializeField] private Transform _point;
    //[SerializeField] private GameObject _fireball;
    [SerializeField] private GameObject _snowBall;
    [SerializeField] private Animator _fireBall;
    private PlayerMovement _player;
    private MoveEnemy _enemy;
    private Animator _anima;
    private int _currentPlayer;
    private int _currentEnemy;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _enemy = FindObjectOfType<MoveEnemy>();
        _anima = GetComponent<Animator>();
        _snowBall.SetActive(false);
    }

    public override void OnTick()
    {
        if (Base.Death == false)
        {
            if (Base.FireBall == true && Base.Go == false)
            {
                _currentEnemy = _enemy.currentFree;
                _currentPlayer = _player.currentPosition;
                if (_currentPlayer == _currentEnemy)
                {
                    _anima.SetBool("Fire", true);
                    _fireBall.speed = Base.PlayerSpeed;
                    Base.FireBall = false;
                }
                else
                {
                    Base.FireBall = false;
                }
            }
        }
    }
    //void Update()
    //{
    //    if (Base.Death == false)
    //    {
    //        if (Base.FireBall == true && Base.Go == false)
    //        {
    //            _currentEnemy = _enemy.currentFree;
    //            _currentPlayer = _player.currentPosition;
    //            if (_currentPlayer == _currentEnemy)
    //            {
    //                _anima.SetBool("Fire", true);
    //                _fireBall.speed = Base.PlayerSpeed;
    //                Base.FireBall = false;
    //            }
    //            else
    //            {                    
    //                Base.FireBall = false;
    //            }
    //        }
    //    }
    //}

    /// <summary>
    /// Реализация выстрела
    /// </summary>
    public void Fire()
    {
        //Instantiate(_fireball, _point.position, Quaternion.identity);
        _snowBall.SetActive(true);
        _fireBall.SetTrigger("Fire");
        _anima.SetBool("Fire", false);
    }
}
