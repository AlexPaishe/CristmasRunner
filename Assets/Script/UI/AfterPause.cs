using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterPause : MonoBehaviour
{
    [SerializeField] private Image _timerImage;
    [SerializeField] private Sprite[] _timerSprites;
    public bool _pause = false;
    private float _timer = 4;
    private float _step;

    void Update()
    {
        if(Base.Pause == true)
        {
            _step = Base.PlayerSpeed * 2;
        }
        if(_pause == true)
        {
            _timer -= Time.deltaTime * _step;
            if(_timer > 3)
            {
                _timerImage.sprite = _timerSprites[0];
            }
            else if(_timer > 2 && _timer < 3)
            {
                _timerImage.sprite = _timerSprites[1];
            }
            else if(_timer > 1 && _timer < 2)
            {
                _timerImage.sprite = _timerSprites[2];
            }
            else if (_timer > 0 && _timer < 1)
            {
                _timerImage.sprite = _timerSprites[2];
            }
            else if(_timer < 0)
            {
                Base.Pause = false;
                _pause = false;
                _timer = 4;
                _timerImage.sprite = _timerSprites[3];
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
