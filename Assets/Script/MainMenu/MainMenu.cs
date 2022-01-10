using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _menu;
    [SerializeField] private Toggle _training;
    [SerializeField] private Toggle[] _variationInput;
    [SerializeField] private TextMeshProUGUI [] _recordTextMesh;
    [SerializeField] private AudioSource _click;
    private string[] _nameRecord = new string[2] { "Easy","Hard"};
    private bool _mobile = false;
    private float[] _record = new float[2] {0,0};

    private void Awake()
    {
        if(PlayerPrefs.GetInt("First") == 0)
        {
            PlayerPrefs.SetInt("First", 1);
            SceneManager.LoadScene(0);
        }

        int training = PlayerPrefs.GetInt("Training");

        switch(training)
        {
            case 0: _training.isOn = true; Base.Training = true; break;
            case 1: _training.isOn = false; Base.Training = false; break;
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
    /// Реализация включение и выключения окна выбора сложности и начала геймплея
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
    /// Реализация включение и выключени меню настроек игры
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
    /// Реализация включение и выключени меню авторов
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
    /// Реализация выбора уровня сложности
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
    /// Реализация выбора режима: тренировка или без неё
    /// </summary>
    /// <param name="var"></param>
    public void Training(bool var)
    {
        if(var == true)
        {
            PlayerPrefs.SetInt("Training", 0);
            Base.Training = true;
        }
        else
        {
            PlayerPrefs.SetInt("Training", 1);
            Base.Training = false;
        }
    }

    /// <summary>
    /// Реализация выбора управления на телефоне ввиде тапа
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
    /// Реализация выбора управления на телефоне ввиде свайпа
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
    /// Реализация выставления рекорда в главном меню
    /// </summary>
    private void ScoreRecord()
    {
        _record[0] = PlayerPrefs.GetFloat("Record");
        _record[1] = PlayerPrefs.GetFloat("HardRecord");

        for(int i = 0; i < _recordTextMesh.Length; i++)
        {
            if (_record[i] / 1000 >= 1)
            {
                _recordTextMesh[i].text = $"{_nameRecord[i]} X {_record[i]}";
            }
            else if (_record[i] / 100 >= 1)
            {
                _recordTextMesh[i].text = $"{_nameRecord[i]} X 0{_record[i]}";
            }
            else if (_record[i] / 10 >= 1)
            {
                _recordTextMesh[i].text = $"{_nameRecord[i]} X 00{_record[i]}";
            }
            else if (_record[i] / 10 >= 0)
            {
                _recordTextMesh[i].text = $"{_nameRecord[i]} X 000{_record[i]}";
            }
        }
    }

    /// <summary>
    /// Реализация включения и выключения меню рекордов
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
    /// Реализация клика
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
