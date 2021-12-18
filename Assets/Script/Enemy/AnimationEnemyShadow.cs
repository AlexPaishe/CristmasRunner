using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemyShadow : MonoBehaviour
{
    [SerializeField] private Material _mat;
    [SerializeField] private Texture2D[] _albedo;
    [SerializeField] private Texture2D[] _normal;
    private int _currentMat = 0;
    private int _maxMat;

    private void Awake()
    {
        _maxMat = _albedo.Length;
    }

    /// <summary>
    /// Создание тени у крампуса
    /// </summary>
    public void ShadowMat()
    {
        //_mesh.material = _mats[_currentMat];
        //_currentMat++;
        //if (_currentMat == _maxMat)
        //{
        //    _currentMat = 0;
        //}
        _mat.SetTexture("_MainTexture", _albedo[_currentMat]);
        _mat.SetTexture("_NormalMap", _normal[_currentMat]);
        _currentMat++;
        if(_currentMat == _maxMat)
        {
            _currentMat = 0;
        }
    }
}
