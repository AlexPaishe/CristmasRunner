using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _menu;
    [SerializeField] private Toggle _training;
    [SerializeField] private Dropdown _variationInput;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("Training") == 0)
        {
            _training.isOn = false;
        }
        else if (PlayerPrefs.GetInt("Training") == 1)
        {
            _training.isOn = true;
        }

        if(PlayerPrefs.GetInt("VariationInput") == 0)
        {
            _variationInput.value = 0;
        }
        else if(PlayerPrefs.GetInt("VariationInput") == 1)
        {
            _variationInput.value = 1;
        }
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
    /// Реализация выключения игры
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Реализация выбора уровня сложности
    /// </summary>
    /// <param name="var"></param>
    public void PlayGame(int var)
    {
        switch(var)
        {
            case 0: PlayerPrefs.SetFloat("HardLevel", 1); SceneManager.LoadScene(1);break;
            case 1: PlayerPrefs.SetFloat("HardLevel", 2); SceneManager.LoadScene(1); break;
            case 2: PlayerPrefs.SetFloat("HardLevel", 3); SceneManager.LoadScene(1); break;
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
        }
        else
        {
            PlayerPrefs.SetInt("Training", 0);
        }
    }

    /// <summary>
    /// Реализация выбора управления на телефоне
    /// </summary>
    /// <param name="var"></param>
    public void VariationInput(int var)
    {
        PlayerPrefs.SetInt("VariationInput", var);
    }
}
