using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereNight : Monocache
{
    [SerializeField] private Vector3 _maxScale;
    [SerializeField] private float _speed;
    private Vector3 _begin;
    private Transform _tr;

    private void Awake()
    {
        _begin = transform.localScale;
        _tr = GetComponent<Transform>();
    }

    public override void OnTick()
    {
        if (Base.Go == true)
        {
            _tr.localScale = Vector3.MoveTowards(transform.localScale, _maxScale, _speed * Base.PlayerSpeed * Time.deltaTime);
        }
        else
        {
            _tr.localScale = Vector3.MoveTowards(transform.localScale, _begin, _speed * Base.PlayerSpeed * Time.deltaTime);
        }
    }
}
