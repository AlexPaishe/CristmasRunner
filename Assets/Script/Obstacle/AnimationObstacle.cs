using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObstacle : MonoBehaviour
{
    [SerializeField] private Animator _anima;
    private bool _go = false; 

    void Update()
    {
        if(Base.Go == true && _go == false)
        {
            _go = true;
            _anima.speed = Base.Speed;
        }
        else if(Base.Go == false && _go == true)
        {
            _anima.speed = Base.PlayerSpeed;
            _go = false;
        }
    }
}
