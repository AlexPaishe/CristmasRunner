using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterPause : MonoBehaviour
{
    [SerializeField] private Text _TimerText;
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
                _TimerText.text = "3";
            }
            else if(_timer > 2 && _timer < 3)
            {
                _TimerText.text = "2";
            }
            else if(_timer > 1 && _timer < 2)
            {
                _TimerText.text = "1";
            }
            else if (_timer > 0 && _timer < 1)
            {
                _TimerText.text = "0";
            }
            else if(_timer < 0)
            {
                Base.Pause = false;
                _pause = false;
                _timer = 4;
                _TimerText.text = "";
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
