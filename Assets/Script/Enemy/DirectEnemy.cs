using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectEnemy : MonoBehaviour
{
    [SerializeField] private CreatPlaform _creat;
    public int CurrentFree;

    void Start()
    {
        CurrentFree = _creat.CurrentPlatformFree;
    }
}
