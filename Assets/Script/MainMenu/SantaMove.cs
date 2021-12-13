using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMove : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _target;
    public int currentFree = 1;
    private bool _go = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Platform"))
        {
            currentFree = collision.gameObject.GetComponent<DirectEnemy>().CurrentFree;
            _go = true;
        }
    }

    private void Update()
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
            if (_enemy.transform.position != _target[currentFree])
            {
                _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _target[currentFree], _speed);
            }
            else
            {
                _go = false;
                Base.FireBall = true;
            }
        }
    }
}
