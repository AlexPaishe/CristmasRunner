using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _phone;
    public Transform PlatformContainer;

    private Transform _lastPhone = null;

    void Start()
    {
        Init();
    }

    /// <summary>
    /// Создание фона
    /// </summary>
    public void CreatPhone()
    {
        Vector3 pos = (_lastPhone == null) ?
            PlatformContainer.position :
            _lastPhone.GetComponent<Phone>().EndPoint.position;
        GameObject res = Instantiate(_phone, pos, Quaternion.identity, PlatformContainer);
        _lastPhone = res.transform;
    }

    /// <summary>
    /// Инициализация фона в начале игры
    /// </summary>
    private void Init()
    {
        for(int i = 0; i < 10; i++)
        {
            CreatPhone();
        }
    }
}
