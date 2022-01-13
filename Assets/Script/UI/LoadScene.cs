using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private Animator _anima;
    private bool _restart = false;

    private void Awake()
    {
        _anima = GetComponent<Animator>();
    }

    private void Start()
    {
        if (Base.Game == true)
        {
            Base.Speed = 0;
        }
    }

    /// <summary>
    /// Реализация выбора новой сцены или повторить эту
    /// </summary>
    /// <param name="var"></param>
    public void StartCrossfade(bool var)
    {
        _anima.SetTrigger("End");
        _restart = var;
    }

    /// <summary>
    /// Реализация перехода на новую сцену
    /// </summary>
    public void EndScene()
    {
        if(_restart == false)
        {
            if(Base.Game == false)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>
    /// Реализация движения послеокончания 
    /// </summary>
    public void EndCrossfade()
    {
        Base.Speed = PlayerPrefs.GetFloat("HardLevel");
    }
}
