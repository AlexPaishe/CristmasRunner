using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMove : Monocache
{
    [SerializeField] private GameObject[] _dark;
    private bool _go = false;

    private void Awake()
    {
        for (int i = 0; i < _dark.Length; i++)
        {
            _dark[i].SetActive(false);
        }
    }

    public override void OnTick()
    {
        if (Base.Go == true && _go == false && Base.Move < 3)
        {
            switch (Base.Move)
            {
                case 0: _dark[0].SetActive(true); break;
                case 1: _dark[1].SetActive(true); break;
                case 2: _dark[2].SetActive(true); break;
            }
            _go = true;
        }
        else if (Base.Go == false && _go == true)
        {
            _go = false;
            for (int i = 0; i < _dark.Length; i++)
            {
                _dark[i].SetActive(false);
            }
        }
    }
}
