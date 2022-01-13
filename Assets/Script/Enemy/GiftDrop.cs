using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftDrop : Monocache
{
    [SerializeField] private GameObject[] _present;
    [SerializeField] private Transform _point;
    [SerializeField] private Animator _anima;
    [SerializeField] private Material[] _mats;
    [SerializeField] private GameObject _snowBall;
    private bool _go = false;
    private float _fade = 1;
    public float Fade
    {
        get
        {
            return _fade;
        }
        set
        {
            _fade = value;
            if(_fade <= 0)
            {
                _go = false;
                _fade = 1;
                _anima.SetTrigger("Begin");
                _snowBall.SetActive(false);
                for(int i = 0; i < _mats.Length; i++)
                {
                    _mats[i].SetFloat("_Fade", _fade);
                }
            }
        }
    }

    public override void OnTick()
    {
        if(_go == true)
        {
            Fade -= Time.deltaTime * 1.5f * Base.PlayerSpeed;
            for(int i = 0; i < _mats.Length; i ++)
            {
                _mats[i].SetFloat("_Fade", Fade);
            }
        }
    }

    /// <summary>
    /// Создание нового подарка при попадании снежка
    /// </summary>
    public void NewGift()
    {
        int rand = Random.Range(0, 101);
        if (Base.Hard == false)
        {
            if (rand > 10 && rand < 95)
            {
                rand = 0;
            }
            else if (rand > 95)
            {
                rand = 2;
            }
            else
            {
                rand = 1;
            }
        }
        else
        {
            if (rand < 95)
            {
                rand = 0;
            }
            else
            {
                rand = 2;
            }
        }
        Instantiate(_present[rand], _point.position, Quaternion.identity);
        _go = true;
    }
}
