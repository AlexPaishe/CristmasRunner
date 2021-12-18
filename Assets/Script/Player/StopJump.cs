using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopJump : MonoBehaviour
{
    private Animator _anima;

    private void Awake()
    {
        _anima = GetComponent<Animator>();
    }

    /// <summary>
    /// Реализация перехода между прыжками
    /// </summary>
    public void MediumJump()
    {
        if (Base.Game == true)
        {
            _anima.SetBool("Start", false);
            Base.Action = false;
        }
    }
}
