using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectEnemy : MonoBehaviour
{
    [SerializeField] private CreatPlaform _creat;
    [SerializeField] private bool _training;
    public int CurrentFree;

    void Start()
    {
        if (_training == false)
        {
            CurrentFree = _creat.CurrentPlatformFree;
        }
    }
}
