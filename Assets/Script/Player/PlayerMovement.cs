using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScreenMobile = UnityEngine.Device.Screen;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3[] _point;
    [SerializeField] private float _speed;
    [SerializeField] private Animator[] _anima;

    public int currentPosition = 1;
    private float _currentSpeed;
    private BoxCollider _box;
    private ActionWindow _action;
    private bool _death = false;
    private bool _pause = false;

    private float _currentHeight = ScreenMobile.height;
    private float _y1;
    private float _y2;

    private void Awake()
    {
        _box = GetComponent<BoxCollider>();
        _action = FindObjectOfType<ActionWindow>();
    }

    private void Update()
    {
        if (Base.Death == false)
        {
            if (Base.Pause == false)
            {
                if(_pause == true)
                {
                    _anima[0].speed = Base.PlayerSpeed;
                    _anima[1].speed = Base.PlayerSpeed;
                    _pause = false;
                }
                if (Base.Go == true)
                {
                    _anima[0].speed = Base.Speed;
                    _anima[1].speed = Base.Speed;
                    Move();
                }

                PositionAndScale();
            }
            else
            {
                if(_anima[0].speed !=0)
                {
                    _anima[0].speed = 0;
                    _anima[1].speed = 0;
                    _pause = true;
                }
            }
        }
        else if(Base.Death == true && _death == false)
        {
            _anima[1].SetTrigger("Death");
            _anima[0].SetTrigger("Death");
            _death = true;
        }
    }

    /// <summary>
    /// Передвижение персонажа
    /// </summary>
    private void Move()
    {
        if(Base.PC == true)
        {
            PCMove();
        }
        else
        {
            if(Base.Mobile == 0)
            {
                MobileMoveFirst();
            }
            else if(Base.Mobile == 1)
            {
                MobileMoveSecond();
            }
        }
    }

    /// <summary>
    /// Перемещение и изменение размеров
    /// </summary>
    private void PositionAndScale()
    {
        if (transform.position != _point[currentPosition])
        {
            transform.position = Vector3.MoveTowards(transform.position, _point[currentPosition], _currentSpeed * Base.Speed);
        }
        else
        {           
            if(Base.Crouch == false)
            {
                Base.FireBall = true;
                Base.Crouch = true;
            }
        }
    }

    /// <summary>
    /// Начало приседания
    /// </summary>
    public void BeginCrouch()
    {
        _anima[0].SetTrigger("BigJump");
        _anima[1].SetBool("Big", true);
    }

    /// <summary>
    /// Изменение колайдера во время большого прыжка
    /// </summary>
    public void BigJumping()
    {
        _box.size = new Vector3(1, 5, 3);
        _box.center = new Vector3(0, 7, 2);
    }

    /// <summary>
    /// Конец приседания
    /// </summary>
    public void EndCrouch()
    {
        _anima[1].SetBool("Big", false);
    }

    /// <summary>
    /// Становление на новую зону
    /// </summary>
    public void NewZone()
    {
        _box.size = new Vector3(1, 5, 3);
        _box.center = new Vector3(0, 2, 2);
    }

    /// <summary>
    /// Реализация управления на ПК
    /// </summary>
    private void PCMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _currentSpeed = _speed * Base.PlayerSpeed;
            currentPosition++;
            if (currentPosition > 2)
            {
                currentPosition = 2;
            }
            if (Base.Training == true)
            {
                Base.Go = false;
            }
            Base.Crouch = false;
            _anima[0].speed = _currentSpeed;
            _anima[1].speed = _currentSpeed;
            _anima[0].SetTrigger("MiniJump");
            _action.NextStep();
            Base.Action = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _currentSpeed = _speed * Base.PlayerSpeed;
            currentPosition--;
            if (currentPosition < 0)
            {
                currentPosition = 0;
            }
            if (Base.Training == true)
            {
                Base.Go = false;
            }
            Base.Crouch = false;
            _anima[0].speed = _currentSpeed;
            _anima[1].speed = _currentSpeed;
            _anima[0].SetTrigger("MiniJump");
            _action.NextStep();
            Base.Action = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            BeginCrouch();
            if (Base.Training == true)
            {
                Base.Go = false;
            }
            Base.Crouch = true;
            _anima[0].speed = _currentSpeed;
            _anima[1].speed = _currentSpeed;
            _action.NextStep();
            Base.Action = true;
        }
    }

    /// <summary>
    /// Реализация управления на мобильном устройстве версия один
    /// </summary>
    private void MobileMoveFirst()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.position.y < _currentHeight/3 && touch.phase == TouchPhase.Began)
            {
                _currentSpeed = _speed * Base.PlayerSpeed;
                currentPosition--;
                if (currentPosition < 0)
                {
                    currentPosition = 0;
                }
                if (Base.Training == true)
                {
                    Base.Go = false;
                }
                Base.Crouch = false;
                _anima[0].speed = _currentSpeed;
                _anima[1].speed = _currentSpeed;
                _anima[0].SetTrigger("MiniJump");
                _action.NextStep();
                Base.Action = true;
            }
            else if(touch.position.y > _currentHeight/3 && touch.position.y < (_currentHeight/3)*2 
                && touch.phase == TouchPhase.Began)
            {
                BeginCrouch();
                if (Base.Training == true)
                {
                    Base.Go = false;
                }
                Base.Crouch = true;
                _anima[0].speed = _currentSpeed;
                _anima[1].speed = _currentSpeed;
                _anima[0].SetTrigger("MiniJump");
                _action.NextStep();
                Base.Action = true;
            }
            else if(touch.position.y > (_currentHeight / 3) * 2 && touch.phase == TouchPhase.Began)
            {
                _currentSpeed = _speed * Base.PlayerSpeed;
                currentPosition++;
                if (currentPosition > 2)
                {
                    currentPosition = 2;
                }
                if (Base.Training == true)
                {
                    Base.Go = false;
                }
                Base.Crouch = false;
                _anima[0].speed = _currentSpeed;
                _anima[1].speed = _currentSpeed;
                _action.NextStep();
                Base.Action = true;
            }
        }
    }

    /// <summary>
    /// Реализация управления на мобильное устройство версия два
    /// </summary>
    private void MobileMoveSecond()
    {
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _y1 = Input.GetTouch(0).position.y;
            }

            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _y2 = Input.GetTouch(0).position.y;

                if(_y1 > _y2)
                {
                    _currentSpeed = _speed * Base.PlayerSpeed;
                    currentPosition--;
                    if (currentPosition < 0)
                    {
                        currentPosition = 0;
                    }
                    if (Base.Training == true)
                    {
                        Base.Go = false;
                    }
                    Base.Crouch = false;
                    _anima[0].speed = _currentSpeed;
                    _anima[1].speed = _currentSpeed;
                    _anima[0].SetTrigger("MiniJump");
                    _action.NextStep();
                    Base.Action = true;
                }
                else if(_y1 < _y2)
                {
                    _currentSpeed = _speed * Base.PlayerSpeed;
                    currentPosition++;
                    if (currentPosition > 2)
                    {
                        currentPosition = 2;
                    }
                    if (Base.Training == true)
                    {
                        Base.Go = false;
                    }
                    Base.Crouch = false;
                    _anima[0].speed = _currentSpeed;
                    _anima[1].speed = _currentSpeed;
                    _anima[0].SetTrigger("MiniJump");
                    _action.NextStep();
                    Base.Action = true;
                }
                else
                {
                    BeginCrouch();
                    if (Base.Training == true)
                    {
                        Base.Go = false;
                    }
                    Base.Crouch = true;
                    _anima[0].speed = _currentSpeed;
                    _anima[1].speed = _currentSpeed;
                    _action.NextStep();
                    Base.Action = true;
                }
            }
        }
        else
        {
            _y1 = 0;
            _y2 = 0;
        }
    }
}
