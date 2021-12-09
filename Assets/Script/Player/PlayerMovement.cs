using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3[] _point;
    [SerializeField] private Vector3[] _size;
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;

    public int currentPosition = 1;
    private float _currentSpeed;
    private float _currentSize;
    private Animator _anima;
    private BoxCollider2D _box;
    private bool _death = false;
    private bool _pause = false;

    private void Awake()
    {
        _anima = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Base.Death == false)
        {
            if (Base.Pause == false)
            {
                if(_pause == true)
                {
                    _anima.speed = Base.PlayerSpeed;
                    _pause = false;
                }
                if (Base.Go == true)
                {
                    _anima.speed = Base.Speed;
                    Move();
                }

                PositionAndScale();
            }
            else
            {
                if(_anima.speed !=0)
                {
                    _anima.speed = 0;
                    _pause = true;
                }
            }
        }
        else if(Base.Death == true && _death == false)
        {
            _anima.SetTrigger("Death");
            _death = true;
        }
    }

    /// <summary>
    /// Передвижение персонажа
    /// </summary>
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _currentSpeed = _speed * Base.PlayerSpeed;
            _currentSize = _stepSize * Base.PlayerSpeed;
            currentPosition++;
            if (currentPosition > 2)
            {
                currentPosition = 2;
            }
            Base.Go = false;
            Base.Crouch = false;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _currentSpeed = _speed * Base.PlayerSpeed;
            _currentSize = _stepSize * Base.PlayerSpeed;
            currentPosition--;
            if (currentPosition < 0)
            {
                currentPosition = 0;
            }
            Base.Go = false;
            Base.Crouch = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            BeginCrouch();
            Base.Go = false;
            Base.Crouch = true;
        }
    }

    /// <summary>
    /// Перемещение и изменение размеров
    /// </summary>
    private void PositionAndScale()
    {
        if (transform.position != _point[currentPosition])
        {
            transform.position = Vector3.MoveTowards(transform.position, _point[currentPosition], _currentSpeed);
        }
        else
        {           
            if(Base.Crouch == false)
            {
                Base.FireBall = true;
                Base.Crouch = true;
            }
        }

        if (transform.localScale != _size[currentPosition])
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, _size[currentPosition], _currentSize);
        }
    }

    /// <summary>
    /// Начало приседания
    /// </summary>
    public void BeginCrouch()
    {
        _anima.SetBool("Crouch", true);
        _box.size = new Vector2(0.14f, 0.08f);
        _box.offset = new Vector2(0, 0.04f);
    }

    /// <summary>
    /// Конец приседания
    /// </summary>
    public void EndCrouch()
    {
        _box.size = new Vector2(0.14f, 0.25f);
        _box.offset = new Vector2(0, 0.13f);
        _anima.SetBool("Crouch", false);
    }
}
