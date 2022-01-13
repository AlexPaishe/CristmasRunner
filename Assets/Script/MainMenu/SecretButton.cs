using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuitMobile = UnityEngine.Device.Application;

public class SecretButton : Monocache
{
    [SerializeField] private Vector3 _maxScale;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject [] _titles; 
    private Vector3 _begin;
    private Transform _tr;
    private bool _go = false;

    void Start()
    {
        _begin = transform.localScale;
        _tr = GetComponent<Transform>();
        for(int i = 0; i < _titles.Length; i++)
        {
            _titles[i].SetActive(false);
        }
        StartCoroutine(Title());
    }

    public override void OnTick()
    {
        if (_go == true && _tr.localScale != _maxScale)
        {
            _tr.localScale = Vector3.MoveTowards(transform.localScale, _maxScale, _speed * Base.PlayerSpeed * Time.deltaTime);
        }
        else if(_go == false && _tr.localScale != _begin)
        {
            _tr.localScale = Vector3.MoveTowards(transform.localScale, _begin, _speed * Base.PlayerSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Реализация боусной изменения картинки в главном меню
    /// </summary>
    public void Holiday()
    {
        _go = !_go;
    }

    /// <summary>
    /// Реализация выхода из телефона
    /// </summary>
    public void Exit()
    {
        QuitMobile.Quit();
    }

    /// <summary>
    /// Включение и выключение табличек с текстом
    /// </summary>
    /// <returns></returns>
    private IEnumerator Title()
    {
        for(; ; )
        {
            float rand = Random.Range(2.5f, 7.5f);
            yield return new WaitForSeconds(rand);
            for (int i = 0; i < _titles.Length; i++)
            {
                _titles[i].SetActive(true);
            }
            float rands = Random.Range(2.5f, 7.5f);
            yield return new WaitForSeconds(rand);
            for (int i = 0; i < _titles.Length; i++)
            {
                _titles[i].SetActive(false);
            }
        }
    }
}
