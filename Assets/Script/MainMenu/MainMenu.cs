using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _menu;
    [SerializeField] private Toggle _training;
    [SerializeField] private Toggle[] _variationInput;
    private bool _mobile = false;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("Training") == 0)
        {
            _training.isOn = false;
            Base.Training = false;
        }
        else if (PlayerPrefs.GetInt("Training") == 1)
        {
            _training.isOn = true;
            Base.Training = true;
        }

        if(PlayerPrefs.GetInt("VariationInput") == 0)
        {
            _variationInput[0].isOn = true;
            _variationInput[1].isOn = false;
        }
        else if(PlayerPrefs.GetInt("VariationInput") == 1)
        {
            _variationInput[0].isOn = false;
            _variationInput[1].isOn = true;
        }
        Base.Pause = false;
    }

    /// <summary>
    /// ���������� ��������� � ���������� ���� ������ ��������� � ������ ��������
    /// </summary>
    public void PlayMenu()
    {
        if(_menu[0].activeSelf)
        {
            _menu[0].SetActive(false);
        }
        else
        {
            _menu[0].SetActive(true);
        }
    }

    /// <summary>
    /// ���������� ��������� � ��������� ���� �������� ����
    /// </summary>
    public void Setting()
    {
        if(_menu[1].activeSelf)
        {
            _menu[1].SetActive(false);
        }
        else
        {
            _menu[1].SetActive(true);
        }
    }

    /// <summary>
    /// ���������� ��������� � ��������� ���� �������
    /// </summary>
    public void Author()
    {
        if (_menu[2].activeSelf)
        {
            _menu[2].SetActive(false);
        }
        else
        {
            _menu[2].SetActive(true);
        }
    }

    /// <summary>
    /// ���������� ������ ������ ���������
    /// </summary>
    /// <param name="var"></param>
    public void PlayGame(int var)
    {
        switch(var)
        {
            case 0: PlayerPrefs.SetFloat("HardLevel", 1); Base.Hard = false; SceneManager.LoadScene(1);break;
            case 1: PlayerPrefs.SetFloat("HardLevel", 2); Base.Hard = true; SceneManager.LoadScene(1); break;
        }
    }

    /// <summary>
    /// ���������� ������ ������: ���������� ��� ��� ��
    /// </summary>
    /// <param name="var"></param>
    public void Training(bool var)
    {
        if(var == true)
        {
            PlayerPrefs.SetInt("Training", 1);
            Base.Training = true;
        }
        else
        {
            PlayerPrefs.SetInt("Training", 0);
            Base.Training = false;
        }
    }

    /// <summary>
    /// ���������� ������ ���������� �� �������� ����� ����
    /// </summary>
    /// <param name="var"></param>
    public void VariationInputFirst(bool var)
    {
        if (var == true)
        {
            PlayerPrefs.SetInt("VariationInput", 0);
            _variationInput[1].isOn = false;
        }
        else
        {
            PlayerPrefs.SetInt("VariationInput", 1);
            _variationInput[1].isOn = true;
        }
    }

    /// <summary>
    /// ���������� ������ ���������� �� �������� ����� ������
    /// </summary>
    /// <param name="var"></param>
    public void VariationInputSecond(bool var)
    {
        if (var == true)
        {
            PlayerPrefs.SetInt("VariationInput", 1);
            _variationInput[0].isOn = false;
        }
        else
        {
            PlayerPrefs.SetInt("VariationInput", 0);
            _variationInput[0].isOn = true;
        }
    }

    private void Update()
    {
        if(Input.touchCount > 0 && _mobile == false)
        {
            Base.PC = false;
            _mobile = true;
        }
        Debug.Log(Base.Training);
    }
}
