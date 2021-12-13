using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    [SerializeField] private GameObject[] _trainingWindow;
    private int _training = 1;
    private int _currentTraining = 0;
    private bool _go = false;

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
        if(_training == 1)
        {
            Base.Training = true;
        }
        for(int i = 0; i < _trainingWindow.Length; i++)
        {
            _trainingWindow[i].SetActive(false);
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
        }
    }
}
