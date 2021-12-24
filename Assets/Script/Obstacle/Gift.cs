using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public bool go = false;
    [SerializeField] private GameObject _obj;
    [SerializeField] private Material[] _mats;
    private Animator _anima;
    private MeshRenderer _mesh;
    private PlayerMovement _player;
    private KillPresent _kill;
    private float _x;
    private bool _gold = false;
    private bool _xPos = false;

    private void Awake()
    {
        _anima = GetComponent<Animator>();
        _mesh = _obj.GetComponent<MeshRenderer>();
        if (FindObjectOfType<PlayerMovement>() != null)
        {
            _player = FindObjectOfType<PlayerMovement>();
            _x = _player.transform.position.x;
        }
        else
        {
            _kill = FindObjectOfType<KillPresent>();
            _x = _kill.transform.position.x;
        }
    }

    void Update()
    {
        if (go == false)
        {
            if (Base.Gold == true && _gold == false)
            {
                _gold = true;
                _anima.SetTrigger("Gold");
            }
            else if (Base.Gold == false && _gold == true)
            {
                _gold = false;
                _anima.SetTrigger("Classic");
            }

            if(transform.position.x < _x && _xPos == false)
            {
                Base.Gold = false;
                _xPos = true;
            }
        }
        else
        {
            go = false;
            _anima.SetTrigger("Death");
        }
    }

    /// <summary>
    /// Реализация уничтожения обЪекта
    /// </summary>
    public void Death()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Реализация смены вида обЪекта
    /// </summary>
    /// <param name="var"></param>
    public void NewDesolve(int var)
    {
        _mesh.material = _mats[var];
    }
}
