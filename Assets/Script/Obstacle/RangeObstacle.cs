using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeObstacle : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private float[] _points;
    [SerializeField] private Vector3[] _sizeObstacle;

    void Start()
    {
        for(int i = 0; i < _points.Length; i ++)
        {
            if(transform.position.y == _points[i])
            {
                _obstacle.transform.localScale = _sizeObstacle[i];
            }
        }
    }
}
