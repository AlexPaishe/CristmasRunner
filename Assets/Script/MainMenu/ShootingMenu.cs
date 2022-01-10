using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMenu : Monocache
{
    //[SerializeField] private Transform _point;
    //[SerializeField] private GameObject _fireball;
    [SerializeField] private GameObject _snowBall;
    [SerializeField] private Animator _fireBall;
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
        _snowBall.SetActive(false);
    }

    public override void OnTick()
    {
        if (Base.FireBall == true)
        {
            _currentEnemy = _enemy.currentFree;
            _currentPlayer = _player.currentFree;
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
    //void Update()
    //{
    //    if (Base.FireBall == true)
    //    {
    //        _currentEnemy = _enemy.currentFree;
    //        _currentPlayer = _player.currentFree;
    //        if (_currentPlayer == _currentEnemy)
    //        {
    //            _anima.SetBool("Fire", true);
    //            Base.FireBall = false;
    //        }
    //        else
    //        {
    //            Base.FireBall = false;
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
