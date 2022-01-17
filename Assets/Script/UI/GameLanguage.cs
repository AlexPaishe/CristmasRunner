using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLanguage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _allText;
    [SerializeField] private string[] _russian;
    [SerializeField] private string[] _english;
    [SerializeField] private Image _langu;
    [SerializeField] private Sprite[] _language;
    private string[] _lang = new string[23];

    public string[] LanguageText
    {
        get
        {
            switch (Base.Language)
            {
                case 0:
                    for (int i = 0; i < _lang.Length; i++)
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
        for (int i = 0; i < _allText.Length; i++)
        {
            _allText[i].text = LanguageText[i];
        }

        switch (Base.Language)
        {
            case 0: _langu.sprite = _language[0]; break;
            case 1: _langu.sprite = _language[1]; break;
        }
    }

    /// <summary>
    /// Реализация смены языка
    /// </summary>
    public void Language()
    {
        if (Base.Language == 0)
        {
            Base.Language = 1;
            _langu.sprite = _language[1];
        }
        else
        {
            Base.Language = 0;
            _langu.sprite = _language[0];
        }

        for (int i = 0; i < _allText.Length; i++)
        {
            _allText[i].text = LanguageText[i];
        }
    }
}
