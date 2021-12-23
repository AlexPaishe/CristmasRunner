using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAndNight : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    [SerializeField] private float _speed;
    [SerializeField] private float _night;
    private bool _go = false;
    private float _currentStep = 130;

    void Update()
    {
        NightAndSunObstacle();
    }

    /// <summary>
    /// Реализация изменения образа при свете и тьме
    /// </summary>
    private void NightAndSunObstacle()
    {
        if(Base.Go == true && _go == false)
        {
            _currentStep += _speed * Base.PlayerSpeed;
            _light.transform.eulerAngles = new Vector3(_currentStep, 180, 0);
            if(_currentStep > _night)
            {
                _go = true;
                _currentStep = _night;
            }
        }
        else if (Base.Go == false && _go == true)
        {
            _currentStep -= _speed * Base.PlayerSpeed;
            _light.transform.eulerAngles = new Vector3(_currentStep, 180, 0);
            if (_currentStep < 130)
            {
                _go = false;
                _currentStep = 130;
            }
        }
    }
}
