using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    [SerializeField] private GameObject[] _trainingWindow;
    [SerializeField] private Animator[] _trainingAnima;
    [SerializeField] private Animator[] _animaSanta;
    [SerializeField] private Animator[] _penAnima;
    [SerializeField] private TextMeshProUGUI[] _rulesTextMesh;
    [SerializeField] private string[] _rules;
    [SerializeField] private PlayerMovement _player;
    private int _training = 1;
    private int _currentTraining = 0;
    private bool _go = false;
    private int _swipe = 0;
    private float _y1;
    private float _y2;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Training"))
        {
            for(int i = 0; i < _trainingWindow.Length; i++)
            {
                if(i == _currentTraining)
                {
                    _trainingWindow[i].SetActive(true);
                }
                else
                {
                    _trainingWindow[i].SetActive(false);
                }
            }
            _currentTraining++;
            _go = true;
        }
        else if(collision.CompareTag("Platform"))
        {
            if (Base.Training == true)
            {
                Base.Training = false;
                PlayerPrefs.SetInt("Training", 0);
            }
        }
    }

    private void Awake()
    {
        _training = PlayerPrefs.GetInt("Training");
        if(_training == 0)
        {
            Base.Training = true;
        }
        for(int i = 0; i < _trainingWindow.Length; i++)
        {
            _trainingWindow[i].SetActive(false);
        }
    }

    private void Start()
    {
        if (Base.Language == 0)
        {
            if (Base.Mobile == 0)
            {
                _rulesTextMesh[0].text = _rules[0];
                _rulesTextMesh[1].text = _rules[1];
                _rulesTextMesh[2].text = _rules[2];
            }
            else if (Base.Mobile == 1)
            {
                _rulesTextMesh[0].text = _rules[3];
                _rulesTextMesh[1].text = _rules[4];
                _rulesTextMesh[2].text = _rules[5];
            }
        }
        else if(Base.Language == 1)
        {
            if (Base.Mobile == 0)
            {
                _rulesTextMesh[0].text = _rules[6];
                _rulesTextMesh[1].text = _rules[7];
                _rulesTextMesh[2].text = _rules[8];
            }
            else if (Base.Mobile == 1)
            {
                _rulesTextMesh[0].text = _rules[9];
                _rulesTextMesh[1].text = _rules[10];
                _rulesTextMesh[2].text = _rules[11];
            }
        }
    }

    private void Update()
    {
        if (Base.Death == false)
        {
            if (Base.Go == false && _go == true)
            {
                for (int i = 0; i < _trainingWindow.Length; i++)
                {
                    _trainingWindow[i].SetActive(false);
                }
                _go = false;
            }
            else if(Base.Go == true)
            {
                SwipeMove();
            }
        }
    }

    /// <summary>
    /// Реализация выхода из анимации
    /// </summary>
    public void EndAnima()
    {
        _trainingAnima[_currentTraining - 1].SetTrigger("End");
    }

    /// <summary>
    /// Реализация перехода на следующуюю ступень обучения
    /// </summary>
    public void Go()
    {
        if (_currentTraining != 5 && _currentTraining !=6 && _currentTraining != 7)
        {
            Base.Go = false;
            _animaSanta[0].speed = Base.PlayerSpeed;
            _animaSanta[1].speed = Base.PlayerSpeed;
            _animaSanta[0].SetTrigger("MiniJump");
            Base.Crouch = false;
        }
        else if(_currentTraining == 5)
        {
            if (Base.Mobile == 0)
            {
                _penAnima[0].SetTrigger("Pen");
            }
            else
            {
                _penAnima[0].SetTrigger("Down");
                _swipe = 1;
            }
        }
        else if(_currentTraining == 6)
        {
            if (Base.Mobile == 0)
            {
                _penAnima[1].SetTrigger("Pen");
            }
            else
            {
                _penAnima[1].SetTrigger("Up");
                _swipe = 2;
            }
        }
        else if (_currentTraining == 7)
        {
            if (Base.Mobile == 0)
            {
                _penAnima[2].SetTrigger("Pen");
            }
            else
            {
                _penAnima[2].SetTrigger("Tap");
                _swipe = 3;
            }
        }
    }

    /// <summary>
    /// Реализация большого прыжка
    /// </summary>
    public void CentreBigJump()
    {
        if (Base.Mobile == 0)
        {
            Base.Go = false;
            _animaSanta[0].speed = Base.PlayerSpeed;
            _animaSanta[1].speed = Base.PlayerSpeed;
            switch (_currentTraining)
            {
                case 5:
                    Base.Crouch = false;
                    _animaSanta[0].SetTrigger("MiniJump");
                    _player.currentPosition--;
                    break;
                case 6:
                    Base.Crouch = false;
                    _animaSanta[0].SetTrigger("MiniJump");
                    _player.currentPosition++;
                    break;
                case 7:
                    Base.Crouch = true;
                    _animaSanta[0].SetTrigger("BigJump");
                    _animaSanta[1].SetBool("Big", true);
                    break;
            }
        }
    }

    /// <summary>
    /// Реализация свайпов в обучении
    /// </summary>
    private void SwipeMove()
    {
        if(Base.Mobile == 1 && Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _y1 = Input.GetTouch(0).position.y;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _y2 = Input.GetTouch(0).position.y;
                if (_y1 < 0)
                {
                    _y1 = _y2;
                }

                if (_y1 > _y2 && _y1 - _y2 > 50 && _swipe == 1)
                {
                    _player.currentPosition--;
                    Base.Crouch = false;
                    Base.Go = false;
                    _animaSanta[0].speed = Base.PlayerSpeed;
                    _animaSanta[1].speed = Base.PlayerSpeed;
                    _animaSanta[0].SetTrigger("MiniJump");
                    _swipe = 0;
                }
                else if (_y1 < _y2 && _y2 - _y1 > 50 && _swipe == 2)
                {
                    _player.currentPosition++;
                    Base.Crouch = false;
                    Base.Go = false;
                    _animaSanta[0].speed = Base.PlayerSpeed;
                    _animaSanta[1].speed = Base.PlayerSpeed;
                    _animaSanta[0].SetTrigger("MiniJump");
                    _swipe = 0;
                }
                else if(_swipe == 3)
                {
                    Base.Crouch = true;
                    Base.Go = false;
                    _animaSanta[0].speed = Base.PlayerSpeed;
                    _animaSanta[1].speed = Base.PlayerSpeed;
                    _animaSanta[0].SetTrigger("BigJump");
                    _animaSanta[1].SetBool("Big", true);
                    _swipe = 0;
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
