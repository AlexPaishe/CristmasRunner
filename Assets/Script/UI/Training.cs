using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    [SerializeField] private GameObject[] _trainingWindow;
    private int _training = 1;
    private int _currentTraining = 0;
    private bool _go = false;

    private void OnTriggerEnter2D(Collider2D collision)
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
            Base.Training = false;
        }
    }

    private void Awake()
    {
        _training = PlayerPrefs.GetInt("Training");
        if(_training == 1)
        {
            Base.Training = true;
        }
        PlayerPrefs.SetInt("Training", 0);
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

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Training", 1);
    }
}
