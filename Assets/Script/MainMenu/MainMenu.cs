using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _menu;
    [SerializeField] private Toggle _vibro;
    [SerializeField] private Toggle[] _variationInput;
    [SerializeField] private TextMeshProUGUI [] _recordTextMesh;
    [SerializeField] private AudioSource _click;
    private bool _mobile = false;
    private float[] _record = new float[2] {0,0};

    private void Awake()
    {
        int vibro = PlayerPrefs.GetInt("Vibro");

        switch(vibro)
        {
            case 0: _vibro.isOn = true; Base.Vibrator = true; break;
            case 1: _vibro.isOn = false; Base.Vibrator = false; break;
        }

        int variations = PlayerPrefs.GetInt("VariationInput");

        switch(variations)
        {
            case 0: _variationInput[0].isOn = true; _variationInput[1].isOn = false; break;
            case 1: _variationInput[0].isOn = false; _variationInput[1].isOn = true; break;
        }
        Base.Pause = false;
        Base.Go = false;
        Base.Speed = 2;
        Base.PlayerSpeed = 2;
        Base.Death = false;
        Base.Game = false;
        Base.Gold = false;

        ScoreRecord();
    }

    /// <summary>
    /// ���������� ��������� � ���������� ���� ������ ��������� � ������ ��������
    /// </summary>
    public void PlayMenu()
    {
        if(_menu[0].activeSelf)
        {
            _menu[0].SetActive(false);
        }
        else
        {
            _menu[0].SetActive(true);
        }
    }

    /// <summary>
    /// ���������� ��������� � ��������� ���� �������� ����
    /// </summary>
    public void Setting()
    {
        if(_menu[1].activeSelf)
        {
            _menu[1].SetActive(false);
        }
        else
        {
            _menu[1].SetActive(true);
        }
    }

    /// <summary>
    /// ���������� ��������� � ��������� ���� �������
    /// </summary>
    public void Author()
    {
        if (_menu[2].activeSelf)
        {
            _menu[2].SetActive(false);
        }
        else
        {
            _menu[2].SetActive(true);
        }
    }

    /// <summary>
    /// ���������� ������ ������ ���������
    /// </summary>
    /// <param name="var"></param>
    public void PlayGame(int var)
    {
        switch(var)
        {
            case 0: PlayerPrefs.SetFloat("HardLevel", 2); Base.Hard = false; break;
            case 1: PlayerPrefs.SetFloat("HardLevel", 2); Base.Hard = true; break;
        }
    }

    /// <summary>
    /// ���������� ������ ������: ���������� ��� ��� ��
    /// </summary>
    /// <param name="var"></param>
    public void Vibrator(bool var)
    {
        if(var == true)
        {
            PlayerPrefs.SetInt("Vibro", 0);
            Base.Vibrator = true;
        }
        else
        {
            PlayerPrefs.SetInt("Vibro", 1);
            Base.Vibrator = false;
        }
    }

    /// <summary>
    /// ���������� ������ ���������� �� �������� ����� ����
    /// </summary>
    /// <param name="var"></param>
    public void VariationInputFirst(bool var)
    {
        if (var == true)
        {
            PlayerPrefs.SetInt("VariationInput", 0);
            _variationInput[1].isOn = false;
        }
        else
        {
            PlayerPrefs.SetInt("VariationInput", 1);
            _variationInput[1].isOn = true;
        }
    }

    /// <summary>
    /// ���������� ������ ���������� �� �������� ����� ������
    /// </summary>
    /// <param name="var"></param>
    public void VariationInputSecond(bool var)
    {
        if (var == true)
        {
            PlayerPrefs.SetInt("VariationInput", 1);
            _variationInput[0].isOn = false;
        }
        else
        {
            PlayerPrefs.SetInt("VariationInput", 0);
            _variationInput[0].isOn = true;
        }
    }

    /// <summary>
    /// ���������� ����������� ������� � ������� ����
    /// </summary>
    private void ScoreRecord()
    {
        _record[0] = PlayerPrefs.GetFloat("Record");
        _record[1] = PlayerPrefs.GetFloat("HardRecord");

        for(int i = 0; i < _recordTextMesh.Length; i++)
        {
            if (_record[i] / 1000 >= 1)
            {
                _recordTextMesh[i].text = $" X {_record[i]}";
            }
            else if (_record[i] / 100 >= 1)
            {
                _recordTextMesh[i].text = $" X 0{_record[i]}";
            }
            else if (_record[i] / 10 >= 1)
            {
                _recordTextMesh[i].text = $" X 00{_record[i]}";
            }
            else if (_record[i] / 10 >= 0)
            {
                _recordTextMesh[i].text = $" X 000{_record[i]}";
            }
        }
    }

    /// <summary>
    /// ���������� ��������� � ���������� ���� ��������
    /// </summary>
    public void RecordMenu()
    {
        if (_menu[3].activeSelf)
        {
            _menu[3].SetActive(false);
        }
        else
        {
            _menu[3].SetActive(true);
        }
    }

    /// <summary>
    /// ���������� �����
    /// </summary>
    public void Click()
    {
        _click.Play();
    }

    private void Update()
    {
        if(Input.touchCount > 0 && _mobile == false)
        {
            Base.PC = false;
            _mobile = true;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("First", 0);
    }
}
