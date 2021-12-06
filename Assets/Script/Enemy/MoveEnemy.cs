using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _target;
    [SerializeField] private Vector3[] _size;
    public int currentFree = 1;
    private Animator _anima;
    private bool _go = false;

    private void Awake()
    {
        _anima = _enemy.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            currentFree = collision.gameObject.GetComponent<DirectEnemy>().CurrentFree;
        }
    }

    private void Update()
    {
        if(Base.Go == true && _go == false)
        {
            _anima.speed = Base.Speed;
            _go = true;
        }
        else if(Base.Go == false && _go == true)
        {
            _anima.speed = Base.PlayerSpeed;
            _go = false;
        }
        if (_enemy.transform.position != _target[currentFree])
        {
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _target[currentFree], _speed);
        }
        if(_enemy.transform.localScale != _size[currentFree])
        {
            _enemy.transform.localScale = Vector3.MoveTowards(_enemy.transform.localScale, _size[currentFree], _speed);
        }
    }
}
