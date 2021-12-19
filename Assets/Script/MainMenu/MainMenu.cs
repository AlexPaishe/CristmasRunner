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
    [SerializeField] private Text _recordText;
    [SerializeField] private TextMeshProUGUI _recordTextMesh;
    private bool _mobile = false;
    private float _record = 0;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("First") == 0)
        {
            PlayerPrefs.SetInt("First", 1);
            SceneManager.LoadScene(0);
        }

        if(PlayerPrefs.GetInt("Training") == 0)
        {
            _training.isOn = false;
            Base.Training = false;
        }
        else if (PlayerPrefs.GetInt("Training") == 1)
        {
            _training.isOn = true;
            Base.Training = true;
        }

        if(PlayerPrefs.GetInt("VariationInput") == 0)
        {
            _variationInput[0].isOn = true;
            _variationInput[1].isOn = false;
        }
        else if(PlayerPrefs.GetInt("VariationInput") == 1)
        {
            _variationInput[0].isOn = false;
            _variationInput[1].isOn = true;
        }
        Base.Pause = false;
        Base.Go = false;
        Base.Speed = 1;
        Base.PlayerSpeed = 1;
        Base.Death = false;
        Base.Game = false;

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
            case 0: PlayerPrefs.SetFloat("HardLevel", 1); Base.Hard = false; SceneManager.LoadScene(1);break;
            case 1: PlayerPrefs.SetFloat("HardLevel", 2); Base.Hard = true; SceneManager.LoadScene(1); break;
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
            PlayerPrefs.SetInt("Training", 1);
            Base.Training = true;
        }
        else
        {
            PlayerPrefs.SetInt("Training", 0);
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
        _record = PlayerPrefs.GetFloat("Record");

        if (_record / 1000 >= 1)
        {
            _recordText.text = $"You Record X {_record}";
            _recordTextMesh.text = $"You Record X {_record}";
        }
        else if (_record / 100 >= 1)
        {
            _recordText.text = $"You Record X 0{_record}";
            _recordTextMesh.text = $"You Record X 0{_record}";
        }
        else if (_record / 10 >= 1)
        {
            _recordText.text = $"You Record X 00{_record}";
            _recordTextMesh.text = $"You Record X 00{_record}";
        }
        else if (_record / 10 >= 0)
        {
            _recordText.text = $"You Record X 000{_record}";
            _recordTextMesh.text = $"You Record X 000{_record}";
        }
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
