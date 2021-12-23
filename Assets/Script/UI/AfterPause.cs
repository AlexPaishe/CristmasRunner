using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterPause : MonoBehaviour
{
    [SerializeField] private Image _timerImage;
    [SerializeField] private Sprite[] _timerSprites;
    [SerializeField] private AudioSource _audio;
    public bool _pause = false;
    private float _timer = 4;
    private float _step = 1;
    private int _current = 0;

    void Update()
    {
        if (Base.Pause == true)
        {
            _step = Base.PlayerSpeed;
        }

        if (_pause == true)
        {
            _timer -= Time.deltaTime * _step;
            if(_timer > 3)
            {
                if(_current == 0)
                {
                    _timerImage.sprite = _timerSprites[_current];
                    _audio.Play();
                    _current++;
                }
            }
            else if(_timer > 2 && _timer < 3)
            {
                if (_current == 1)
                {
                    _timerImage.sprite = _timerSprites[_current];
                    _audio.Play();
                    _current++;
                }
            }
            else if(_timer > 1 && _timer < 2)
            {
                if (_current == 2)
                {
                    _timerImage.sprite = _timerSprites[_current];
                    _audio.Play();
                    _current++;
                }
            }
            else if (_timer > 0 && _timer < 1)
            {
                if (_current == 3)
                {
                    _timerImage.sprite = _timerSprites[_current];
                    _audio.Play();
                    _current++;
                }
            }
            else if(_timer < 0)
            {
                if (_current == 4)
                {
                    Base.Pause = false;
                    _pause = false;
                    _timer = 4;
                    _timerImage.sprite = _timerSprites[4];
                    _current = 0;
                }
            }
        }
    }

    /// <summary>
    /// Реализация запуса отсчёта
    /// </summary>
    public void PauseEnd()
    {
        _pause = true;
    }
}
