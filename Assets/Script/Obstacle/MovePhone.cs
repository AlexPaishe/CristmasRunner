using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhone : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Material _mat;
    private float _offset = 0;

    void Update()
    {
        if (Base.Go == false && Base.Death == false && Base.Pause == false)
        {
            _offset += _speed * Time.deltaTime;
            _mat.SetFloat("_Offset", _offset);
        }
    }
}
