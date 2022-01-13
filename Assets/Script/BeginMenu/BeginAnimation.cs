using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anima;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string[] _languageText;
    [SerializeField] private AudioSource _audio;
    public string Language
    {
        get
        {
            return _languageText[Base.Language];
        }

        set
        {

        }
    }

    /// <summary>
    /// Реализация изменения языка
    /// </summary>
    /// <param name="var"></param>
    public void LanguageChange(int var)
    {
        Base.Language = var;
        _text.text = Language;
        _audio.Play();
        _anima.SetTrigger("End");
    }

    /// <summary>
    /// Включение главного меню
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
