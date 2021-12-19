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
        _record = PlayerPrefs.GetFloat("Record");

        if (_record / 1000 >= 1)
        {
            _scoreDeath.text = $"You Record X {_record}";
            _scoreDeathMesh.text = $"You Record X {_record}";
        }
        else if (_record / 100 >= 1)
        {
            _scoreDeath.text = $"You Record X 0{_record}";
            _scoreDeathMesh.text = $"You Record X 0{_record}";
        }
        else if (_record / 10 >= 1)
        {
            _scoreDeath.text = $"You Record X 00{_record}";
            _scoreDeathMesh.text = $"You Record X 00{_record}";
        }
        else if (_record / 10 >= 0)
        {
            _scoreDeath.text = $"You Record X 000{_record}";
            _scoreDeathMesh.text = $"You Record X 000{_record}";
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Gift"))
        {
            _giftCount++;
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
            collision.GetComponent<Desolve>().go = true;
        }
    }

    private void Update()
    {
        if(Base.Death == true)
        {
            if(_giftCount > _record)
            {
                PlayerPrefs.SetFloat("Record", _giftCount);
                if (_giftCount / 1000 >= 1)
                {
                    _scoreDeath.text = $"New Record X {_giftCount}";
                    _scoreDeathMesh.text = $"New Record X {_giftCount}";
                }
                else if (_giftCount / 100 >= 1)
                {
                    _scoreDeath.text = $"New Record X 0{_giftCount}";
                    _scoreDeathMesh.text = $"New Record X 0{_giftCount}";
                }
                else if (_giftCount / 10 >= 1)
                {
                    _scoreDeath.text = $"New Record X 00{_giftCount}";
                    _scoreDeathMesh.text = $"New Record X 00{_giftCount}";
                }
                else if (_giftCount / 10 >= 0)
                {
                    _scoreDeath.text = $"New Record X 000{_giftCount}";
                    _scoreDeathMesh.text = $"New Record X 000{_giftCount}";
                }
            }
            else if (_giftCount == _record || _giftCount < _record)
            {
                if (_giftCount / 1000 >= 1)
                {
                    _scoreDeath.text = $"You Score X {_giftCount}";
                    _scoreDeathMesh.text = $"You Score X {_giftCount}";
                }
                else if (_giftCount / 100 >= 1)
                {
                    _scoreDeath.text = $"You Score X 0{_giftCount}";
                    _scoreDeathMesh.text = $"You Score X 0{_giftCount}";
                }
                else if (_giftCount / 10 >= 1)
                {
                    _scoreDeath.text = $"You Score X 00{_giftCount}";
                    _scoreDeathMesh.text = $"You Score X 00{_giftCount}";
                }
                else if (_giftCount / 10 >= 0)
                {
                    _scoreDeath.text = $"You Score X 000{_giftCount}";
                    _scoreDeathMesh.text = $"You Score X 000{_giftCount}";
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
