using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private float _speed;
    private bool _go = false;
    private float _beginMusic;

    private void Start()
    {
        _beginMusic = Base.PlayerSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Training") && _go == false || other.CompareTag("Platform") && _go == false)
        {
            _go = true;
            _music.pitch = _speed * (Base.PlayerSpeed/_beginMusic);
            _music.Play();
        }
        else if(other.CompareTag("Training") || other.CompareTag("Platform"))
        {
            _music.pitch = _speed * (Base.PlayerSpeed / _beginMusic);
        }
    }

    void Update()
    {
        if(_music.isPlaying == false)
        {
            _go = false;
        }
    }
}
