using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrator : MonoBehaviour
{
    private bool _go = false;

    private void Awake()
    {
        int vibro = PlayerPrefs.GetInt("Vibro");
        switch (vibro)
        {
            case 0: Base.Vibrator = true; break;
            case 1: Base.Vibrator = false; break;
        }
    }

    private void Update()
    {
        if (Base.Vibrator == true)
        {
            if (_go == false && Base.Go == true)
            {
                _go = true;
                Handheld.Vibrate();
            }
            else if (_go == true && Base.Go == false)
            {
                _go = false;
            }
        }
    }
}
