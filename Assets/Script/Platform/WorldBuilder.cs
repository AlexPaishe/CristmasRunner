using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private GameObject[] _training;
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
        int index = Random.Range(0, _platforms.Length);
        GameObject res = Instantiate(_platforms[index], pos, Quaternion.identity, PlatformContainer);
        _lastPhone = res.transform;
    }

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
    /// Создание начальных платформ
    /// </summary>
    private void Init()
    {
        if(Base.Training == true)
        {
            for(int i = 0; i < _training.Length; i++)
            {
                CreatTraining();
            }
        }
        for (int i = 0; i < 8; i++)
        {
            CreatPhone();
        }
    }
}
