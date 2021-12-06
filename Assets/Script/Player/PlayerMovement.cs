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

    private void Awake()
    {
        _anima = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(Base.Go == true)
        {
            _anima.speed = Base.Speed;
            Move();
        }

        PositionAndScale();
    }

    /// <summary>
    /// ������������ ���������
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
    /// ����������� � ��������� ��������
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
    /// ������ ����������
    /// </summary>
    public void BeginCrouch()
    {
        _anima.SetBool("Crouch", true);
        _box.size = new Vector2(0.14f, 0.08f);
        _box.offset = new Vector2(0, 0.04f);
    }

    /// <summary>
    /// ����� ����������
    /// </summary>
    public void EndCrouch()
    {
        _box.size = new Vector2(0.14f, 0.25f);
        _box.offset = new Vector2(0, 0.13f);
        _anima.SetBool("Crouch", false);
    }
}
