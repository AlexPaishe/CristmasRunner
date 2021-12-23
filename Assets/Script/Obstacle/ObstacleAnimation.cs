using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimation : MonoBehaviour
{
    [SerializeField] private Material[] _sunMats;
    [SerializeField] private Material[] _nightMats;
    [SerializeField] private MeshRenderer _mesh;
    private bool _go = false;
    private Animator _anima;

    void Start()
    {
        _anima = GetComponent<Animator>();
    }

    void Update()
    {
        if(Base.Go == true && _go == false)
        {
            _go = true;
            _anima.SetTrigger("Night");
            _anima.speed = Base.PlayerSpeed;
        }
        else if(Base.Go == false && _go == true)
        {
            _go = false;
            _anima.SetTrigger("Day");
            _anima.speed = Base.PlayerSpeed;
        }
    }

    /// <summary>
    /// Реализация анимации в фазу бездействия
    /// </summary>
    /// <param name="var"></param>
    public void Day(int var)
    {
        _mesh.material = _sunMats[var];
    }

    /// <summary>
    /// Реализация анимации в фазу действия
    /// </summary>
    /// <param name="var"></param>
    public void Night(int var)
    {
        _mesh.material = _nightMats[var];
    }
}
