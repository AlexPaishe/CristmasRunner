using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAndNight : MonoBehaviour
{
    [SerializeField] private Material[] _obstacle;
    [SerializeField] private Texture2D[] _albedo;
    [SerializeField] private Texture2D[] _normal;
    private bool _go = false;

    void Update()
    {
        NightAndSunObstacle();
    }

    /// <summary>
    /// Реализация изменения образа при свете и тьме
    /// </summary>
    private void NightAndSunObstacle()
    {
        if(Base.Go == true && _go == false)
        {
            _go = true;
            for (int i = 0; i < _obstacle.Length; i++)
            {
                _obstacle[i].SetTexture("_MainTex", _albedo[i*i]);
                _obstacle[i].SetTexture("_NormalMap", _normal[i*i]);
            }
        }
        else if (Base.Go == false && _go == true)
        {
            _go = false;
            for (int i = 0; i < _obstacle.Length; i++)
            {
                _obstacle[i].SetTexture("_MainTex", _albedo[i+2]);
                _obstacle[i].SetTexture("_NormalMap", _normal[i+2]);
            }
        }
    }
}
