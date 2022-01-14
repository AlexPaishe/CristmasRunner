using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScreenMobile = UnityEngine.Device.Screen;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3[] _point;
    [SerializeField] private float _speed;
    [SerializeField] private Animator[] _anima;
    [SerializeField] private float _swipeNumber;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _layer;

    public int currentPosition = 1;
    private float _currentSpeed;
    private BoxCollider _box;
    private bool _death = false;
    private bool _pause = false;

    private float _y1;
    private float _y2;
    private bool _actionMove = false;
    private bool _movement = false;

    private void Awake()
    {
        _box = GetComponent<BoxCollider>();
        _currentSpeed = _speed * Base.PlayerSpeed;
    }

    private void Start()
    {
        _anima[0].speed = Base.PlayerSpeed;
        _anima[1].speed = Base.PlayerSpeed;
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

                if (Base.Go == true && _actionMove == false)
                {
                    _movement = true;
                    _actionMove = true;
                }
                else if (Base.Go == false && _actionMove == true)
                {
                    _actionMove = false;
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
        if (Base.Training == false)
        {
            if (Base.PC == true)
            {
                PCMove();
            }
            else
            {
                if (Base.Mobile == 0)
                {
                    MobileMoveFirst();
                }
                else if (Base.Mobile == 1)
                {
                    MobileMoveSecond();
                }
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
        if (Input.GetKeyDown(KeyCode.W) && _movement == true && currentPosition != 2)
        {
            _currentSpeed = _speed * Base.PlayerSpeed;
            currentPosition++;
            if (Base.Training == true)
            {
                Base.Go = false;
            }
            Base.Crouch = false;
            _anima[0].speed = _currentSpeed;
            _anima[1].speed = _currentSpeed;
            _anima[0].SetTrigger("MiniJump");
            Base.Action = true;
            _movement = false;
            Base.Move = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _movement == true && currentPosition != 0)
        {
            _currentSpeed = _speed * Base.PlayerSpeed;
            currentPosition--;
            if (Base.Training == true)
            {
                Base.Go = false;
            }
            Base.Crouch = false;
            _anima[0].speed = _currentSpeed;
            _anima[1].speed = _currentSpeed;
            _anima[0].SetTrigger("MiniJump");
            Base.Action = true;
            _movement = false;
            Base.Move = 2;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _movement == true)
        {
            BeginCrouch();
            if (Base.Training == true)
            {
                Base.Go = false;
            }
            Base.Crouch = true;
            _anima[0].speed = _currentSpeed;
            _anima[1].speed = _currentSpeed;
            Base.Action = true;
            _movement = false;
            Base.Move = 1;
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
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit, _maxDistance, _layer) && _movement == true)
            {
                if (hit.transform.position.z == _point[currentPosition].z + 2)
                {
                    BeginCrouch();
                    if (Base.Training == true)
                    {
                        Base.Go = false;
                    }
                    Base.Crouch = true;
                    _anima[0].speed = _currentSpeed;
                    _anima[1].speed = _currentSpeed;
                    Base.Action = true;
                    _movement = false;
                    Base.Move = 1;
                }
                else if (hit.transform.position.z == _point[currentPosition].z - 8 && currentPosition != 0)
                {
                    _currentSpeed = _speed * Base.PlayerSpeed;
                    currentPosition--;
                    if (Base.Training == true)
                    {
                        Base.Go = false;
                    }
                    Base.Crouch = false;
                    _anima[0].speed = _currentSpeed;
                    _anima[1].speed = _currentSpeed;
                    _anima[0].SetTrigger("MiniJump");
                    Base.Action = true;
                    _movement = false;
                    Base.Move = 2;
                }
                else if(hit.transform.position.z == _point[currentPosition].z + 12 && currentPosition != 2)
                {
                    _currentSpeed = _speed * Base.PlayerSpeed;
                    currentPosition++;
                    if (Base.Training == true)
                    {
                        Base.Go = false;
                    }
                    Base.Crouch = false;
                    _anima[0].speed = _currentSpeed;
                    _anima[1].speed = _currentSpeed;
                    _anima[0].SetTrigger("MiniJump");
                    Base.Action = true;
                    _movement = false;
                    Base.Move = 0;
                }
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
            if(Input.GetTouch(0).phase == TouchPhase.Began && _movement == true)
            {
                _y1 = Input.GetTouch(0).position.y;
            }

            if(Input.GetTouch(0).phase == TouchPhase.Ended && _movement == true)
            {
                _y2 = Input.GetTouch(0).position.y;
                if(_y1 < 0)
                {
                    _y1 = _y2;
                }

                if(_y1 > _y2 && _y1 - _y2 > _swipeNumber && currentPosition != 0)
                {
                    _currentSpeed = _speed * Base.PlayerSpeed;
                    currentPosition--;
                    if (Base.Training == true)
                    {
                        Base.Go = false;
                    }
                    Base.Crouch = false;
                    _anima[0].speed = _currentSpeed;
                    _anima[1].speed = _currentSpeed;
                    _anima[0].SetTrigger("MiniJump");
                    Base.Action = true;
                    _movement = false;
                    Base.Move = 2;
                }
                else if(_y1 < _y2 && _y2 - _y1 > _swipeNumber && currentPosition != 2)
                {
                    _currentSpeed = _speed * Base.PlayerSpeed;
                    currentPosition++;
                    if (Base.Training == true)
                    {
                        Base.Go = false;
                    }
                    Base.Crouch = false;
                    _anima[0].speed = _currentSpeed;
                    _anima[1].speed = _currentSpeed;
                    _anima[0].SetTrigger("MiniJump");
                    Base.Action = true;
                    _movement = false;
                    Base.Move = 0;
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
                    Base.Action = true;
                    _movement = false;
                    Base.Move = 1;
                }
            }
        }
        else
        {
            _y1 = -1;
            _y2 = -1;
        }
    }
}
