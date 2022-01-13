using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Textlanguage : MonoBehaviour
{
    [SerializeField] private Image _languageButton;
    [SerializeField] private Sprite[] _flag;
    [SerializeField] private TextMeshProUGUI[] _allText;
    [SerializeField] private string[] _russian;
    [SerializeField] private string[] _english;
    private string[] _lang = new string[19];

    public string[] LanguageText
    {
        get
        {            
            switch(Base.Language)
            {
                case 0: 
                    for(int i = 0; i < _lang.Length; i++)
                    {
                        _lang[i] = _russian[i];
                    }
                    break;
                case 1:
                    for (int i = 0; i < _lang.Length; i++)
                    {
                        _lang[i] = _english[i];
                    }
                    break;
            }
            return _lang;
        }
        set
        {

        }
    }

    private void Awake()
    {
        _languageButton.sprite = _flag[Base.Language];
        for (int i = 0; i < _allText.Length; i++)
        {
            _allText[i].text = LanguageText[i];
        }
    }

    /// <summary>
    /// Реализация смены языка
    /// </summary>
    /// <param name="var"></param>
    public void NewLanguage()
    {
        switch(Base.Language)
        {
            case 0: Base.Language = 1;
                 _languageButton.sprite = _flag[Base.Language];
                 for (int i = 0; i < _allText.Length; i++)
                 {
                    _allText[i].text = LanguageText[i];
                 }
                break;
            case 1: Base.Language = 0;
                _languageButton.sprite = _flag[Base.Language];
                for (int i = 0; i < _allText.Length; i++)
                {
                    _allText[i].text = LanguageText[i];
                }
                break;
        }
    }
}
