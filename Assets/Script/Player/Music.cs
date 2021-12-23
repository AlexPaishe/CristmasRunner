using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _pauseMusic;
    [SerializeField] private AudioClip[] _musicStep;
    [SerializeField] private float _speed;
    private bool _mute = false;
    private bool _step = false;
    private float _beginMusic;
    private int _currentLevel;
    private int _maxLevel;
    private ActionWindow _action;

    private void Start()
    {
        _beginMusic = Base.PlayerSpeed;
        _action = FindObjectOfType<ActionWindow>();
        _maxLevel = _musicStep.Length;
        if(Base.Training == true)
        {
            _pauseMusic.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            if (_step == false)
            {
                _step = true;
                _action.Step();
            }

            if (_action.Next() == true)
            {
                _pauseMusic.Pause();
                if (_currentLevel < _maxLevel)
                {
                    _music.clip = _musicStep[_currentLevel];
                    _music.pitch = 1;
                    _currentLevel++;
                    _beginMusic = Base.PlayerSpeed;
                }
                else
                {
                    _music.pitch = _speed * (Base.PlayerSpeed / _beginMusic);
                }
                _music.Stop();
                _music.Play();
            }
        }       
    }

    void Update()
    {
        if(Base.Pause == false && _mute == true)
        {
            _music.Play();
            _pauseMusic.Pause();
            _mute = false;
        }
        else if(Base.Pause == true && _mute == false)
        {
            _music.Pause();
            _pauseMusic.Play();
            _mute = true;
        }
    }
}
