using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionWindow : MonoBehaviour
{
    //[SerializeField] private Camera _cam;
    //[SerializeField] private LayerMask[] _layers;
    [SerializeField] private float _timer;
    [SerializeField] private float _step;
    [SerializeField] private int _nextLevel;
    [SerializeField] private bool _static;
    [SerializeField] private bool _frameFill;
    [SerializeField] private Image _frame;
    [SerializeField] private Animator[] _anima;

    private bool _go = false;
    private int _currentLevel = 0;
    private float _currentTimer;
    private float _multiply;
    private float _stepFrame;

    private PlayerMovement _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>();
    }

    private void Start()
    {
        _multiply = PlayerPrefs.GetFloat("HardLevel");
        _currentTimer = _timer;
        _frame.fillAmount = 0;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Platform") && _static == true || collision.CompareTag("Training") && _static == true)
        {
            //_cam.cullingMask = _layers[0];
            Base.PlayerSpeed = Base.Speed;
            Base.Speed = 0;
            _go = true;
            Base.Go = true;
            _currentTimer = _timer;
            _currentTimer /= _multiply;
            _stepFrame = (1 / _currentTimer);
            _frame.fillAmount = 1;
            NextStep();
        }

        if (collision.CompareTag("Dynamic") && _static == false)
        {
            //_cam.cullingMask = _layers[0];
            Base.Speed = _multiply;
            Base.PlayerSpeed = Base.Speed;
            Base.Go = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Dynamic") && _static == false)
        {
            //_cam.cullingMask = _layers[1];
            Base.Go = false;
            if (_currentLevel == _nextLevel)
            {
                _multiply += _step;
                _currentLevel = 0;
            }
            else
            {
                _currentLevel++;
            }
        }
    }

    private void Update()
    {
        if (Base.Death == false)
        {
            if (Base.Pause == false)
            {
                if (Base.Go == true && _static == true && _go == true)
                {
                    StaticVariation();                   
                }
                else if (Base.Go == false && _go == true)
                {
                    Action();
                }
            }
        }
    }

    /// <summary>
    /// Статическая вариация
    /// </summary>
    private void StaticVariation()
    {
        if (Base.Training == false)
        {
            _currentTimer -= Time.deltaTime;
            if (_frameFill == true)
            {
                _frame.fillAmount -= (_stepFrame * Time.deltaTime);
            }
        }

        if (_currentTimer < 0)
        {
            Base.Speed = _multiply;
            //_cam.cullingMask = _layers[1];
            Base.Go = false;
            _anima[0].speed = 1 * Base.PlayerSpeed;
            _anima[1].speed = 1 * Base.PlayerSpeed;
            if(Base.Action == false)
            {
                _anima[0].SetTrigger("MiniJump");
                Base.Crouch = false;
            }
        }
    }

    /// <summary>
    /// Обнуление переменных при действии
    /// </summary>
    private void Action()
    {
        _go = false;
        Base.Speed = _multiply;
        Base.PlayerSpeed = _multiply;
        //_cam.cullingMask = _layers[1];
        _currentTimer = _timer;
        _currentTimer /= _multiply;
        _frame.fillAmount = 0;
        _player.NewZone();
    }

    /// <summary>
    /// Ускорение движения
    /// </summary>
    public void NextStep()
    {
        if (_currentLevel == _nextLevel)
        {
            _multiply += _step;
            _currentLevel = 0;
        }
        else
        {
            _currentLevel++;
        }
    }

    /// <summary>
    /// Переход на новую ступень
    /// </summary>
    /// <returns></returns>
    public bool Next()
    {
        bool Yes = false;
        if(_currentLevel == 1)
        {
            Yes = true;
        }
        return Yes;
    }

    /// <summary>
    /// Реализация первого шага после тренировки
    /// </summary>
    public void Step()
    {
        _currentLevel = 1;
    }
}
