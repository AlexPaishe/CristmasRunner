using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLanguage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _allText;
    [SerializeField] private string[] _russian;
    [SerializeField] private string[] _english;
    private string[] _lang = new string[17];

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
    }
}
