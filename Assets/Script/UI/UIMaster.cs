using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour
{
    [SerializeField] private Animator _anima;
    private bool _go = true;
    private Score _score;
    private AfterPause _after;

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
    }

    /// <summary>
    /// ¬ключение меню паузы
    /// </summary>
    public void StartAndPause()
    {
        if (Base.Death == false && _after._pause == false)
        {
            if (_go == true)
            {
                _go = false;
                Base.Pause = true;
                _anima.SetBool("Pause", true);
            }
            else
            {
                _go = true;
                _anima.SetBool("Pause", false);
            }
        }
    }

    private void Update()
    {
        if(_score.death == true)
        {
            _anima.SetBool("Pause", true);
        }
    }
}
