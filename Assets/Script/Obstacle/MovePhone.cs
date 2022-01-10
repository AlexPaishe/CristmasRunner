using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhone : Monocache
{
    [SerializeField] private float _speed;
    [SerializeField] private Material _mat;
    private float _offsetPhone = 0;
    private float _offsetHouse = 0;

    public override void OnTick()
    {
        if (Base.Go == false && Base.Death == false && Base.Pause == false)
        {
            float speed = _speed * Time.deltaTime * Base.PlayerSpeed;
            _offsetPhone += speed * 0.7f;
            _offsetHouse += speed;
            _mat.SetFloat("_PhoneOffset", _offsetPhone);
            _mat.SetFloat("_HouseOffset", _offsetHouse);
        }
    }
}
