using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _platforms;
    [SerializeField] private GameObject[] _training;
    [SerializeField] private GameObject _freePlatform;
    public Transform PlatformContainer;

    private Transform _lastPhone = null;
    private int _currentTraining = 0;

    void Start()
    {
        Init();
    }

    /// <summary>
    /// Создание платформы
    /// </summary>
    public void CreatPhone()
    {
        Vector3 pos = (_lastPhone == null) ?
            PlatformContainer.position :
            _lastPhone.GetComponent<PlatformBuilder>().EndPoint.position;
        GameObject res = Instantiate(_platforms, pos, Quaternion.identity, PlatformContainer);
        _lastPhone = res.transform;
    }

    /// <summary>
    /// Создание тренировочной платформы
    /// </summary>
    public void CreatTraining()
    {
        Vector3 pos = (_lastPhone == null) ?
            PlatformContainer.position :
            _lastPhone.GetComponent<PlatformBuilder>().EndPoint.position;
        GameObject res = Instantiate(_training[_currentTraining], pos, Quaternion.identity, PlatformContainer);
        _lastPhone = res.transform;
        _currentTraining++;
    }

    /// <summary>
    /// Создание пустой платформы
    /// </summary>
    public void CreatFree()
    {
        Vector3 pos = (_lastPhone == null) ?
            PlatformContainer.position :
            _lastPhone.GetComponent<PlatformBuilder>().EndPoint.position;
        GameObject res = Instantiate(_freePlatform, pos, Quaternion.identity, PlatformContainer);
        _lastPhone = res.transform;
    }

    /// <summary>
    /// Создание начальных платформ
    /// </summary>
    private void Init()
    {
        for(int i = 0; i < 4; i++)
        {
            CreatFree();
        }
        if (Base.Training == true)
        {
            for(int i = 0; i < _training.Length; i++)
            {
                CreatTraining();
            }
        }
        for (int i = 0; i < 9; i++)
        {
            CreatPhone();
        }
    }
}
