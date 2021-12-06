using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeObstacle : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private int _varObstacle;
    [SerializeField] private Vector3[] _points;
    [SerializeField] private Vector3[] _positionObstacle;
    [SerializeField] private Vector3[] _sizeObstacle;
    void Start()
    {
        if (transform.localPosition == _points[0]) ;
        for(int i = 0; i < _points.Length; i++)
        {
            if(transform.localPosition == _points[i])
            {

            }
        }
    }
}
