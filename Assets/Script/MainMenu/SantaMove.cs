using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMove : Monocache
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _target;
    public int currentFree = 1;
    private bool _go = false;
    private Transform _tr;

    private void Awake()
    {
        _tr = _enemy.GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Platform"))
        {
            currentFree = collision.gameObject.GetComponent<DirectEnemy>().CurrentFree;
            _go = true;
        }
    }

    public override void OnTick()
    {
        Move();
    }

    /// <summary>
    /// Реализация передвижения санты
    /// </summary>
    private void Move()
    {
        if (_go == true)
        {
            if (_tr.position != _target[currentFree])
            {
                _tr.position = Vector3.MoveTowards(_tr.position, _target[currentFree], _speed);
            }
            else
            {
                _go = false;
                Base.FireBall = true;
            }
        }
    }
}
