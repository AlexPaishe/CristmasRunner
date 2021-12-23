using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desolve : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private Material[] _mats;
    private Animator _anima;
    private MeshRenderer _mesh;
    public bool go = false;

    private void Awake()
    {
        _anima = GetComponent<Animator>();
        _mesh = _obj.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(go == true)
        {
            _anima.SetTrigger("Death");
            go = false;
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
