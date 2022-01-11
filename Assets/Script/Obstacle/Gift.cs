using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : Monocache
{
    public bool go = false;
    [SerializeField] private bool _golding;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private Material[] _mats;
    [SerializeField] private MeshRenderer _shadow;
    private PlayerMovement _player;
    private KillPresent _kill;
    private float _x;
    private bool _gold = false;
    private bool _xPos = false;
    private float _inverse = 1;
    private float _fade = 1;

    private void Awake()
    {
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
        if(_golding == true)
        {
            _mesh.material.SetFloat("_InverseGolding", 0);
            _mesh.material.SetFloat("_VariationLight", 1);
            _inverse = 0;
        }
    }

    public override void OnTick()
    {
        if (go == false)
        {
            if (Base.Gold == true && _gold == false && _golding == false)
            {
                _gold = true;
                _mesh.material.SetFloat("_VariationLight", 1);
                StartCoroutine(Gold());
            }
            else if (Base.Gold == false && _gold == true && _golding == false)
            {
                _gold = false;
                _mesh.material.SetFloat("_VariationLight", 0);
                StartCoroutine(Classic());
            }

            if (transform.position.x < _x && _xPos == false)
            {
                Base.Gold = false;
                _xPos = true;
            }
        }
        else
        {
            go = false;
            StartCoroutine(Deaths());
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

    /// <summary>
    /// Изменение в золотой подарок
    /// </summary>
    /// <returns></returns>
    private IEnumerator Gold()
    {
        while(_inverse > 0)
        {
            _inverse -= Time.deltaTime * Base.PlayerSpeed;
            _mesh.material.SetFloat("_InverseGolding", _inverse);
            yield return null;
        }
        _inverse = 0;
        _mesh.material.SetFloat("_InverseGolding", _inverse);
    }

    /// <summary>
    /// Превращение в классический подарок
    /// </summary>
    /// <returns></returns>
    private IEnumerator Classic()
    {
        while(_inverse < 1)
        {
            _inverse += Time.deltaTime * Base.PlayerSpeed;
            _mesh.material.SetFloat("_InverseGolding", _inverse);
            yield return null;
        }
        _inverse = 1;
        _mesh.material.SetFloat("_InverseGolding", _inverse);
    }

    /// <summary>
    /// РЕализация смери подарка
    /// </summary>
    /// <returns></returns>
    private IEnumerator Deaths()
    {
        while (_fade > 0)
        {
            _fade -= Time.deltaTime * Base.PlayerSpeed;
            _mesh.material.SetFloat("_Fade", _fade);
            _shadow.material.SetFloat("_Fade", _fade);
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
