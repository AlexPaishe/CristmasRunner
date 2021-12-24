using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    [SerializeField] private GameObject[] _trainingWindow;
    [SerializeField] private Text[] _rulesText;
    [SerializeField] private TextMeshProUGUI[] _rulesTextMesh;
    [SerializeField] private string[] _rules;
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
        if (Base.PC == true)
        {
            _rulesText[0].text = _rules[0];
            _rulesText[1].text = _rules[1];
            _rulesTextMesh[0].text = _rules[0];
            _rulesTextMesh[1].text = _rules[1];
        }
        else
        {
            if (Base.Mobile == 0)
            {
                _rulesText[0].text = _rules[2];
                _rulesText[1].text = _rules[3];
                _rulesTextMesh[0].text = _rules[2];
                _rulesTextMesh[1].text = _rules[3];
            }
            else if (Base.Mobile == 1)
            {
                _rulesText[0].text = _rules[4];
                _rulesText[1].text = _rules[5];
                _rulesTextMesh[0].text = _rules[4];
                _rulesTextMesh[1].text = _rules[5];
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
        }
    }
}
