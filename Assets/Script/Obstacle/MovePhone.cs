using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhone : Monocache
{
    [SerializeField] private float _speed;
    [SerializeField] private Material[] _mats;
    private float _offsetPhone = 0;
    private float _offsetHouse = 0;

    public override void OnTick()
    {
        if (Base.Go == false && Base.Death == false && Base.Pause == false)
        {
            float speed = _speed * Time.deltaTime * Base.PlayerSpeed;
            _offsetPhone += speed * 0.7f;
            _offsetHouse += speed;
            for (int i = 0; i < _mats.Length; i++)
            {
                _mats[i].SetFloat("_PhoneOffset", _offsetPhone);
                _mats[i].SetFloat("_HouseOffset", _offsetHouse);
            }
        }
    }
}
