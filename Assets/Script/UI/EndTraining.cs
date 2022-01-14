using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTraining : MonoBehaviour
{
    [SerializeField] private Training _training;

    /// <summary>
    /// Реализация окончания анимации тренировки
    /// </summary>
    public void Go()
    {
        _training.Go();
    }
}
