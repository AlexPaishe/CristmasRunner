using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibrator : MonoBehaviour
{
    private bool _go = false;

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
