using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private GameObject []_enemy;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _target;
    public int currentFree = 1;
    private Animator _anima;
    private bool _go = false;
    private bool _pause = false;

    private void Awake()
    {
        _anima = _enemy[0].GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Platform"))
        {
            currentFree = collision.gameObject.GetComponent<DirectEnemy>().CurrentFree;
        }
    }

    private void Update()
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
            if (_enemy[1].transform.position != _target[currentFree])
            {
                _enemy[1].transform.position = Vector3.MoveTowards(_enemy[1].transform.position, _target[currentFree], _speed);
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
