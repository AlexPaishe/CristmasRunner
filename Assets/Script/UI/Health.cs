using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Animator[] _anima;
    private int _health = 0;
    private bool _go = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Health"))
        {
            _health++;
            if(_health > 3)
            {
                _health = 3;
            }
            for(int i = 0; i < _anima.Length; i++)
            {
                _anima[i].speed = 1 * Base.PlayerSpeed;
            }
            HealthBar();
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Damage"))
        {
            _health--;
            for (int i = 0; i < _anima.Length; i++)
            {
                _anima[i].speed = 1 * Base.PlayerSpeed;
            }
            Debug.Log(_health);
            Damage();
        }
    }

    /// <summary>
    /// Реализация изображения хп в начале игры
    /// </summary>
    public void Begin()
    {
        switch(Base.CurrentHealth)
        {
            case 0: _anima[Base.CurrentHealth].SetTrigger("Begin"); break;
            case 1: _anima[Base.CurrentHealth].SetTrigger("Begin"); break;
            case 2: _anima[Base.CurrentHealth].SetTrigger("Begin"); break;
        }
    }

    /// <summary>
    /// Реализация заполнения хп в начале игры
    /// </summary>
    public void OpenHeart()
    {
        if (_go == false)
        {
            switch (Base.CurrentHealth)
            {
                case 0:  Base.CurrentHealth++; _health++; break;
                case 1:  Base.CurrentHealth++; _health++; break;
                case 2:  Base.CurrentHealth++; _health++; _go = true; break;
            }
        }
    }

    /// <summary>
    /// Реализация получения урона
    /// </summary>
    public void Damage()
    {
        if(_health < Base.CurrentHealth)
        {
            switch(_health)
            {
                case 2: _anima[_health].SetBool("Heart", false); Base.CurrentHealth--; break;
                case 1: _anima[_health].SetBool("Heart", false); Base.CurrentHealth--; break;
                case 0: _anima[_health].SetBool("Heart", false); Base.CurrentHealth--; Base.Speed = 0; break;
            }           
        }
    }

    /// <summary>
    /// Реализация востановления хп
    /// </summary>
    public void HealthBar()
    {
        if(_health > Base.CurrentHealth)
        {
            _anima[Base.CurrentHealth].SetBool("Heart", true); Base.CurrentHealth++;
        }
    }
}
