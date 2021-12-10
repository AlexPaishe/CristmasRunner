using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour
{
    [SerializeField] private Text _startText;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private string[] _pauseAndStart;
    [SerializeField] private Animator[] _anima;
    [SerializeField] private GameObject _setting;
    private bool _go = true;
    private Score _score;

    private void Awake()
    {
        _score = FindObjectOfType<Score>();
        Base.PlayerSpeed = PlayerPrefs.GetFloat("HardLevel");
        Base.Speed = PlayerPrefs.GetFloat("HardLevel");
        Base.Mobile = PlayerPrefs.GetInt("VariationInput");
        Base.Death = false;
        Base.Go = false;
        Base.Training = false;
        Base.CurrentHealth = 0;
        Base.CurrentFree = 1;
        Base.FireBall = false;
        Base.Crouch = true;
        Base.Pause = false;
    }

    /// <summary>
    /// Включение меню паузы
    /// </summary>
    public void StartAndPause()
    {
        if (Base.Death == false)
        {
            if (_go == true)
            {
                _startText.text = _pauseAndStart[0];
                _go = false;
                _buttonImage.color = Color.green;
                Base.Pause = true;
                _anima[0].SetBool("Pause", true);
            }
            else
            {
                _startText.text = _pauseAndStart[1];
                _buttonImage.color = Color.cyan;
                _go = true;
                _anima[0].SetBool("Pause", false);
            }
        }
    }

    private void Update()
    {
        if(_score.death == true)
        {
            _anima[1].SetTrigger("Death");
        }
    }

    /// <summary>
    /// Перезагрузка Уровня
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// /РЕализация выхода в меню
    /// </summary>
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Включение и выключение меню настроек
    /// </summary>
    public void Setting()
    {
        if(_setting.activeSelf)
        {
            _setting.SetActive(false);
        }
        else
        {
            _setting.SetActive(true);
        }
    }
}
