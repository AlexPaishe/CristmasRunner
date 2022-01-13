using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private TextMeshProUGUI _scoreTextMesh;
    [SerializeField] private TextMeshProUGUI _scoreDeathMesh;
    [SerializeField] private Text _scoreDeath;

    private float _giftCount = 0;
    private float _record = 0;
    private PlayerMovement _player;

    public bool death = false;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>();
        if (Base.Hard == false)
        {
            _record = PlayerPrefs.GetFloat("Record");
        }
        else
        {
            _record = PlayerPrefs.GetFloat("HardRecord");
        }

        if (_record / 1000 >= 1)
        {
            switch(Base.Language)
            {
                case 0:
                    _scoreDeath.text = $"Рекорд X {_record}";
                    _scoreDeathMesh.text = $"Рекорд X {_record}";
                    break;
                case 1:
                    _scoreDeath.text = $"High Score X {_record}";
                    _scoreDeathMesh.text = $"High Score X {_record}";
                    break;
            }
        }
        else if (_record / 100 >= 1)
        {
            switch (Base.Language)
            {
                case 0:
                    _scoreDeath.text = $"Рекорд X 0{_record}";
                    _scoreDeathMesh.text = $"Рекорд X 0{_record}";
                    break;
                case 1:
                    _scoreDeath.text = $"High Score X 0{_record}";
                    _scoreDeathMesh.text = $"High Score X 0{_record}";
                    break;
            }
        }
        else if (_record / 10 >= 1)
        {
            switch (Base.Language)
            {
                case 0:
                    _scoreDeath.text = $"Рекорд X 00{_record}";
                    _scoreDeathMesh.text = $"Рекорд X 00{_record}";
                    break;
                case 1:
                    _scoreDeath.text = $"High Score X 00{_record}";
                    _scoreDeathMesh.text = $"High Score X 00{_record}";
                    break;
            }
        }
        else if (_record / 10 >= 0)
        {
            switch (Base.Language)
            {
                case 0:
                    _scoreDeath.text = $"Рекорд X 000{_record}";
                    _scoreDeathMesh.text = $"Рекорд X 000{_record}";
                    break;
                case 1:
                    _scoreDeath.text = $"High Score X 000{_record}";
                    _scoreDeathMesh.text = $"High Score X 000{_record}";
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Gift"))
        {
            if (Base.Gold == false)
            {
                _giftCount++;
            }
            else
            {
                _giftCount += 2;
            }

            string numer = "";
            if(_giftCount /1000 >= 1)
            {
                 numer = $"X{_giftCount}";
            }
            else if(_giftCount/100 >= 1)
            {
                 numer = $"X0{_giftCount}";
            }
            else if (_giftCount/10 >= 1)
            {
                 numer = $"X00{_giftCount}";
            }
            else if (_giftCount /10 > 0)
            {
                 numer = $"X000{_giftCount}";
            }
            _scoreText.text = numer;
            _scoreTextMesh.text = numer;
            if (collision.GetComponent<Desolve>() != null)
            {
                collision.GetComponent<Desolve>().go = true;
            }
            else
            {
                collision.GetComponent<Gift>().go = true;
                collision.GetComponent<FireBall>().Stop();
            }
        }
        else if(collision.CompareTag("Gold"))
        {
            Base.Gold = true;
            _giftCount += 2;
            string numer = "";
            if (_giftCount / 1000 >= 1)
            {
                numer = $"X{_giftCount}";
            }
            else if (_giftCount / 100 >= 1)
            {
                numer = $"X0{_giftCount}";
            }
            else if (_giftCount / 10 >= 1)
            {
                numer = $"X00{_giftCount}";
            }
            else if (_giftCount / 10 > 0)
            {
                numer = $"X000{_giftCount}";
            }
            _scoreText.text = numer;
            _scoreTextMesh.text = numer;
            collision.GetComponent<Gift>().go = true;
            collision.GetComponent<FireBall>().Stop();
        }
    }

    private void Update()
    {
        if(Base.Death == true)
        {
            if(_giftCount > _record)
            {
                if (Base.Hard == false)
                {
                    PlayerPrefs.SetFloat("Record", _giftCount);
                }
                else
                {
                    PlayerPrefs.SetFloat("HardRecord", _giftCount);
                }

                if (_giftCount / 1000 >= 1)
                {
                    switch (Base.Language)
                    {
                        case 0:
                            _scoreDeath.text = $"Hовый Рекорд X {_record}";
                            _scoreDeathMesh.text = $"Hовый Рекорд X {_record}";
                            break;
                        case 1:
                            _scoreDeath.text = $"New High Score X {_record}";
                            _scoreDeathMesh.text = $"New High Score X {_record}";
                            break;
                    }
                }
                else if (_giftCount / 100 >= 1)
                {
                    switch (Base.Language)
                    {
                        case 0:
                            _scoreDeath.text = $"Hовый Рекорд X 0{_record}";
                            _scoreDeathMesh.text = $"Hовый Рекорд X 0{_record}";
                            break;
                        case 1:
                            _scoreDeath.text = $"New High Score X 0{_record}";
                            _scoreDeathMesh.text = $"New High Score X 0{_record}";
                            break;
                    }
                }
                else if (_giftCount / 10 >= 1)
                {
                    switch (Base.Language)
                    {
                        case 0:
                            _scoreDeath.text = $"Hовый Рекорд X 00{_record}";
                            _scoreDeathMesh.text = $"Hовый Рекорд X 00{_record}";
                            break;
                        case 1:
                            _scoreDeath.text = $"New High Score X 00{_record}";
                            _scoreDeathMesh.text = $"New High Score X 00{_record}";
                            break;
                    }
                }
                else if (_giftCount / 10 >= 0)
                {
                    switch (Base.Language)
                    {
                        case 0:
                            _scoreDeath.text = $"Hовый Рекорд X 000{_record}";
                            _scoreDeathMesh.text = $"Hовый Рекорд X 000{_record}";
                            break;
                        case 1:
                            _scoreDeath.text = $"New High Score X 000{_record}";
                            _scoreDeathMesh.text = $"New High Score X 000{_record}";
                            break;
                    }
                }
            }
            else if (_giftCount == _record || _giftCount < _record)
            {
                if (_giftCount / 1000 >= 1)
                {
                    switch (Base.Language)
                    {
                        case 0:
                            _scoreDeath.text = $"Подарки X {_record}";
                            _scoreDeathMesh.text = $"Подарки X {_record}";
                            break;
                        case 1:
                            _scoreDeath.text = $"Your Score X {_record}";
                            _scoreDeathMesh.text = $"Your Score X {_record}";
                            break;
                    }
                }
                else if (_giftCount / 100 >= 1)
                {
                    switch (Base.Language)
                    {
                        case 0:
                            _scoreDeath.text = $"Подарки X 0{_record}";
                            _scoreDeathMesh.text = $"Подарки X 0{_record}";
                            break;
                        case 1:
                            _scoreDeath.text = $"Your Score X 0{_record}";
                            _scoreDeathMesh.text = $"Your Score X 0{_record}";
                            break;
                    }
                }
                else if (_giftCount / 10 >= 1)
                {
                    switch (Base.Language)
                    {
                        case 0:
                            _scoreDeath.text = $"Подарки X 00{_record}";
                            _scoreDeathMesh.text = $"Подарки X 00{_record}";
                            break;
                        case 1:
                            _scoreDeath.text = $"Your Score X 00{_record}";
                            _scoreDeathMesh.text = $"Your Score X 00{_record}";
                            break;
                    }
                }
                else if (_giftCount / 10 >= 0)
                {
                    switch (Base.Language)
                    {
                        case 0:
                            _scoreDeath.text = $"Подарки X 000{_record}";
                            _scoreDeathMesh.text = $"Подарки X 000{_record}";
                            break;
                        case 1:
                            _scoreDeath.text = $"Your Score X 000{_record}";
                            _scoreDeathMesh.text = $"Your Score X 000{_record}";
                            break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Реализация смерти
    /// </summary>
    public void Death()
    {
        death = true;
    }

    /// <summary>
    /// Реализация окончания высокого прыжка
    /// </summary>
    public void EndCrouch()
    {
        _player.EndCrouch();
    }

    /// <summary>
    /// Реализация изменения коллайдера во время прыжка
    /// </summary>
    public void BigJumping()
    {
        _player.BigJumping();
    }
}
