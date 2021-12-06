using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour
{
    [SerializeField] private Text _startText;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private string[] _pauseAndStart;
    private bool _go = false;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartAndPause()
    {
        if(_go == true)
        {
            _startText.text = _pauseAndStart[0];
            _go = false;
            _buttonImage.color = Color.green;
            Time.timeScale = 0;
        }
        else
        {
            _startText.text = _pauseAndStart[1];
            _buttonImage.color = Color.cyan;
            _go = true;
            Time.timeScale = 1;
        }
    }
}
