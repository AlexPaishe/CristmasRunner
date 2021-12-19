using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public Transform EndPoint;
    [SerializeField] private Transform[] _ends;
    [SerializeField] private Texture2D[] _albedo;
    [SerializeField] private MeshRenderer[] _mesh;
    [SerializeField] private bool _city = false;

    private void Awake()
    {
        if(_city == false)
        {
            EndPoint = _ends[0];
            _mesh[1].enabled = false;
            _mesh[0].enabled = true;
        }
        else
        {
            _mesh[0].enabled = false;
            _mesh[1].enabled = true;
            EndPoint = _ends[1];
        }
    }

    void Start()
    {
        PhoneController.Instance.OnPhoneMovement += TryDelAndAddPhone;
        if (_city == false)
        {
            int rand = Random.Range(0, _albedo.Length);
            if (rand != Base.House)
            {
                _mesh[0].material.SetTexture("_MainTexture", _albedo[rand]);
                Base.House = rand;
            }
            else
            {
                rand++;
                if (rand == _albedo.Length)
                {
                    rand = 0;
                }
                _mesh[0].material.SetTexture("_MainTexture", _albedo[rand]);
                Base.House = rand;
            }
        }
    }

    /// <summary>
    /// Удаление и создание платформы при уходе за определенную зону
    /// </summary>
    private void TryDelAndAddPhone()
    {
        if (transform.position.x < PhoneController.Instance.minX)
        {
            PhoneController.Instance.phoneBuilder.CreatPhone();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (PhoneController.Instance != null)
        {
            PhoneController.Instance.OnPhoneMovement -= TryDelAndAddPhone;
        }
    }
}
