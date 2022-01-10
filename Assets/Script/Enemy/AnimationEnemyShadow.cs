using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemyShadow : MonoBehaviour
{
    [SerializeField] private Material[] _mats;
    [SerializeField] private Material[] _shadow;
    [SerializeField] private MeshRenderer[] _mesh;
    private int _currentMat = 0;
    private int _maxMat;
    private void Awake()
    {
        _maxMat = _mats.Length;
    }

    /// <summary>
    /// Создание тени у крампуса
    /// </summary>
    public void ShadowMat()
    {
        _mesh[0].material = _mats[_currentMat];
        _mesh[1].material = _shadow[_currentMat];
        _currentMat++;
        if (_currentMat == _maxMat)
        {
            _currentMat = 0;
        }
    }
}
