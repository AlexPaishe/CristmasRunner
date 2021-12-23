using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour
{
    [SerializeField] private Animator _anima;
    [SerializeField] private Sprite[] _startAndPause;
    [SerializeField] private Image _buttonPause;
    private bool _go = true;
    private bool _begin = true;
    private Score _score;
    private AfterPause _after;
    private AudioSource _audio;

    private void Awake()
    {
        _score = FindObjectOfType<Score>();
        _after = FindObjectOfType<AfterPause>();
        Base.Mobile = PlayerPrefs.GetInt("VariationInput");
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
        _audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// ¬ключение меню паузы
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
    }

    /// <summary>
    /// –еализование звука клика
    /// </summary>
    public void Click()
    {
        _audio.Play();
    }
}
