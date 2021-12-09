using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObstacle : MonoBehaviour
{
    [SerializeField] private Animator _anima;
    private bool _go = false;
    private bool _pause = false;

    void Update()
    {
        if (Base.Death == false)
        {
            if (Base.Pause == false)
            {
                if(_pause == true)
                {
                    _anima.speed = Base.PlayerSpeed;
                    _pause = false;
                }
                if (Base.Go == true && _go == false)
                {
                    _go = true;
                    _anima.speed = Base.Speed;
                }
                else if (Base.Go == false && _go == true)
                {
                    _anima.speed = Base.PlayerSpeed;
                    _go = false;
                }
            }
            else
            {
                if(_anima.speed !=0)
                {
                    _pause = true;
                    _anima.speed = 0;
                }
            }
        }
        else
        {
            _anima.speed = 0;
        }
    }
}
