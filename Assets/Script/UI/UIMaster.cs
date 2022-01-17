using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour
{
    [SerializeField] private Animator _anima;
    [SerializeField] private Sprite[] _startAndPause;
    [SerializeField] private Image _buttonPause;
    [SerializeField] private Animator _animaGift;
    [SerializeField] private GameObject _setting;
    [SerializeField] private Image[] _variations;
    [SerializeField] private Sprite[] _isOn;
    private bool _go = true;
    private bool _gold = false;
    private bool _begin = true;
    private bool _vars = false;
    private bool _vibro = false;
    private Score _score;
    private AfterPause _after;
    private AudioSource _audio;

    private void Awake()
    {
        _score = FindObjectOfType<Score>();
        _after = FindObjectOfType<AfterPause>();
        int variations = PlayerPrefs.GetInt("VariationInput");

        switch (variations)
        {
            case 0: _variations[0].sprite = _isOn[1]; _variations[1].sprite = _isOn[0]; _vars = false; break;
            case 1: _variations[0].sprite = _isOn[0]; _variations[1].sprite = _isOn[1]; _vars = true; break;
        }

        Base.Mobile = variations;
        Base.Death = false;
        Base.Go = false;
        Base.CurrentHealth = 0;
        Base.CurrentFree = 1;
        Base.FireBall = false;
        Base.Crouch = true;
        Base.Pause = false;
        Base.Game = true;
        Base.PlayerSpeed = PlayerPrefs.GetFloat("HardLevel");
        Base.Speed = PlayerPrefs.GetFloat("HardLevel");
        Base.Gold = false;
        _audio = GetComponent<AudioSource>();

        int vibro = PlayerPrefs.GetInt("Vibro");
        switch (vibro)
        {
            case 0: _variations[2].sprite = _isOn[1]; _vibro = true; Base.Vibrator = true; break;
            case 1: _variations[2].sprite = _isOn[0]; _vibro = false; Base.Vibrator = false; break;
        }
    }

    /// <summary>
    /// Включение меню паузы
    /// </summary>
    public void StartAndPause()
    {
        if (Base.Death == false && _after._pause == false && Base.Training == false)
        {
            if (_begin == false)
            {
                if (_go == true)
                {
                    _go = false;
                    Base.Pause = true;
                    _anima.SetBool("Pause", true);
                    _buttonPause.sprite = _startAndPause[0];

                }
                else
                {
                    _go = true;
                    _anima.SetBool("Pause", false);
                    _setting.SetActive(false);
                    _buttonPause.sprite = _startAndPause[1];
                }
            }
        }
    }

    private void Update()
    {
        if(_score.death == true)
        {
            _anima.SetBool("Pause", true);
        }

        if(Base.Go == true && _begin == true)
        {
            _begin = false;
        }

        if(Base.Gold == true && _gold == false)
        {
            _gold = true;
            _animaGift.SetTrigger("Gold");
        }
        else if (Base.Gold == false && _gold == true)
        {
            _gold = false;
            _animaGift.SetTrigger("Classic");
        }
    }

    /// <summary>
    /// Реализование звука клика
    /// </summary>
    public void Click()
    {
        _audio.Play();
    }

    /// <summary>
    /// Реализация включение и выключение меню настроек
    /// </summary>
    /// <param name="var"></param>
    public void Setting(int var)
    {
        switch(var)
        {
            case 0:  _setting.SetActive(true); break;
            case 1:  _setting.SetActive(false); break;
        }
    }

    /// <summary>
    /// Реализация выбора управления 
    /// </summary>
    /// <param name="var"></param>
    public void VariationInput()
    {
        if (_vars == true)
        {
            PlayerPrefs.SetInt("VariationInput", 0);
            Base.Mobile = 0;
            _variations[1].sprite = _isOn[0];
            _variations[0].sprite = _isOn[1];
            _vars = false;
        }
        else
        {
            PlayerPrefs.SetInt("VariationInput", 1);
            Base.Mobile = 1;
            _variations[0].sprite = _isOn[0];
            _variations[1].sprite = _isOn[1];
            _vars = true;
        }
    }

    /// <summary>
    /// Реализация выбора режима: тренировка или без неё
    /// </summary>
    /// <param name="var"></param>
    public void Vibratoring()
    {
        if (_vibro == false)
        {
            PlayerPrefs.SetInt("Vibro", 0);
            Base.Vibrator = true;
            _variations[2].sprite = _isOn[1];
            _vibro = true;
        }
        else
        {
            PlayerPrefs.SetInt("Vibro", 1);
            Base.Vibrator = false;
            _variations[2].sprite = _isOn[0];
            _vibro = false;
        }
    }
}
