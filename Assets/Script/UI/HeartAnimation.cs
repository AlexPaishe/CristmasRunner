using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAnimation : MonoBehaviour
{
    [SerializeField] private Health _health;

    /// <summary>
    /// Реализация изображения хп в начале игры
    /// </summary>
    public void Begin()
    {
        _health.Begin();
    }

    /// <summary>
    /// Реализация заполнения хп в начале игры
    /// </summary>
    public void OpenHeart()
    {
        _health.OpenHeart();
    }
}
