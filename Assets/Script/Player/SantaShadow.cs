using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaShadow : MonoBehaviour
{
    [SerializeField] private Material[] _mat;
    [SerializeField] private Material[] _shadowMat;
    [SerializeField] private GameObject _obj;
    [SerializeField] private GameObject _shadow;
    [SerializeField] private Vector3[] _size;
    [SerializeField] private Vector3[] _points;

    private MeshRenderer _mesh;
    private MeshRenderer _meshShadow;
    private Transform _shadowTr;
    private Transform _tr;
    private float[] _shadowSize = new float[2];

    private void Awake()
    {
        _mesh = _obj.GetComponent<MeshRenderer>();
        _meshShadow = _shadow.GetComponent<MeshRenderer>();
        _shadowTr = _shadow.GetComponent<Transform>();
        _shadowSize[0] = _shadowTr.localScale.z;
        _shadowSize[1] = _shadowSize[0] * (_size[4].z / _size[0].z);
        _tr = _obj.GetComponent<Transform>();
    }

    /// <summary>
    /// Создание тени Санты
    /// </summary>
    /// <param name="var"></param>
    public void Shadow(int var)
    {
        _mesh.material = _mat[var];
        _meshShadow.material = _shadowMat[var];
        _tr.localPosition = _points[var];
        _tr.localScale = _size[var];
        if(var > 3 && var < 10)
        {
            Vector3 Shadow = _shadowTr.localScale;
            Shadow.z = _shadowSize[1];
            _shadowTr.localScale = Shadow;
        }
        else
        {
            Vector3 Shadow = _shadowTr.localScale;
            Shadow.z = _shadowSize[0];
            _shadowTr.localScale = Shadow;
        }
    }
} 
