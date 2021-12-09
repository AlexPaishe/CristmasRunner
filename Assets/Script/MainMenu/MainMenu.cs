using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _Menu;

    /// <summary>
    /// Реализация включение и выключения окна выбора сложности и начала геймплея
    /// </summary>
    public void PlayMenu()
    {
        if(_Menu[0].activeSelf)
        {
            _Menu[0].SetActive(false);
        }
        else
        {
            _Menu[0].SetActive(true);
        }
    }

    /// <summary>
    /// Реализация включение и выключени меню настроек игры
    /// </summary>
    public void Setting()
    {
        if(_Menu[1].activeSelf)
        {
            _Menu[1].SetActive(false);
        }
        else
        {
            _Menu[1].SetActive(true);
        }
    }

    /// <summary>
    /// Реализация выключения игры
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    public void PlayGame(int var)
    {
        switch(var)
        {
            case 0: Base.Speed = 1;Base.PlayerSpeed = 1;SceneManager.LoadScene(1);break;
            case 1: Base.Speed = 2; Base.PlayerSpeed = 2; SceneManager.LoadScene(1); break;
            case 2: Base.Speed = 3; Base.PlayerSpeed = 3; SceneManager.LoadScene(1); break;
        }
    }
}
