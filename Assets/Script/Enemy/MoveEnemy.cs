using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : Monocache
{
    [SerializeField] private GameObject []_enemy;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _target;
    public int currentFree = 1;
    private Animator _anima;
    private bool _go = false;
    private bool _pause = false;
    private Transform _tr;

    private void Awake()
    {
        _anima = _enemy[0].GetComponent<Animator>();
        _tr = _enemy[1].GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Platform")|| collision.CompareTag("Training"))
        {
            currentFree = collision.gameObject.GetComponent<DirectEnemy>().CurrentFree;
        }
    }

    public override void OnTick()
    {
        if (Base.Death == false)
        {
            Move();
        }
        else
        {
            _anima.speed = 0;
        }
    }

    /// <summary>
    /// Реализация передвижения врага
    /// </summary>
    private void Move()
    {
        if (Base.Pause == false)
        {
            if (_pause == true)
            {
                _pause = false;
                _anima.speed = Base.PlayerSpeed;
            }
            if (Base.Go == true && _go == false)
            {
                _anima.speed = Base.Speed;
                _go = true;
            }
            else if (Base.Go == false && _go == true)
            {
                _anima.speed = Base.PlayerSpeed;
                _go = false;
            }
            if (_tr.position != _target[currentFree])
            {
                _tr.position = Vector3.MoveTowards(_tr.position, _target[currentFree], _speed);
            }
        }
        else
        {
            if (_anima.speed != 0)
            {
                _anima.speed = 0;
                _pause = true;
            }
        }
    }
}
