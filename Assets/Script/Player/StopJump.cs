using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopJump : MonoBehaviour
{
    private Animator _anima;
    private bool _go = false;

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
            if (Base.Speed > 0 && _go == false)
            {
                _anima.SetBool("Start", false);
                _go = true;
            }
            Base.Action = false;
        }
    }
}
