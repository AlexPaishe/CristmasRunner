using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatPlaform : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject[] _obstaclePlatform;
    [SerializeField] private GameObject _freePlatform;

    public int CurrentPlatformFree = 0;

    void Start()
    {
        CreatPlatform();
    }

    /// <summary>
    /// Создание свободной платформы
    /// </summary>
    private void NextFree()
    {
        int rand = Random.Range(0, 101); 
        if(Base.CurrentFree == 0 || Base.CurrentFree == 2)
        {
            if(rand < 31)
            {
                CurrentPlatformFree = Base.CurrentFree;
                Instantiate(_freePlatform, _points[CurrentPlatformFree].position, Quaternion.identity, this.gameObject.transform);
            }
            else if(rand > 31)
            {
                CurrentPlatformFree = 1;
                Base.CurrentFree = 1;
                Instantiate(_freePlatform, _points[CurrentPlatformFree].position, Quaternion.identity, this.gameObject.transform);
            }
        }
        else if(Base.CurrentFree == 1)
        {
            if(rand < 36)
            {
                CurrentPlatformFree = 0;
                Base.CurrentFree = 0;
                Instantiate(_freePlatform, _points[CurrentPlatformFree].position, Quaternion.identity, this.gameObject.transform);
            }
            else if(rand > 35 && rand < 66)
            {
                CurrentPlatformFree = 1;
                Base.CurrentFree = 1;
                Instantiate(_freePlatform, _points[CurrentPlatformFree].position, Quaternion.identity, this.gameObject.transform);
            }
            else if(rand > 65)
            {
                CurrentPlatformFree = 2;
                Base.CurrentFree = 2;
                Instantiate(_freePlatform, _points[CurrentPlatformFree].position, Quaternion.identity, this.gameObject.transform);
            }
        }
    }

    /// <summary>
    /// Создание платформы с препятствиями
    /// </summary>
    private void NextObstacle()
    {
        for(int i = 0; i < _points.Length; i++)
        {
            if(i != Base.CurrentFree)
            {
                int rand = Random.Range(0, _obstaclePlatform.Length);
                Instantiate(_obstaclePlatform[rand], _points[i].position, Quaternion.identity, this.gameObject.transform);
            }
        }
    }

    /// <summary>
    /// Создание платформы
    /// </summary>
    private void CreatPlatform()
    {
        NextFree();
        NextObstacle();
    }
}
