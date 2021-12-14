using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaShadow : MonoBehaviour
{
    [SerializeField] private Material[] _mats;
    [SerializeField] private GameObject _obj;
    [SerializeField] private Vector3[] _size;
    [SerializeField] private Vector3[] _points;

    private MeshRenderer _mesh;

    private void Awake()
    {
        _mesh = _obj.GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// Создание тени Санты
    /// </summary>
    /// <param name="var"></param>
    public void Shadow(int var)
    {
        _mesh.material = _mats[var];
        _obj.transform.localPosition = _points[var];
        _obj.transform.localScale = _size[var];
    }
} 
