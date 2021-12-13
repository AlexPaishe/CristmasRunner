using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public Transform EndPoint;

    void Start()
    {
        PhoneController.Instance.OnPhoneMovement += TryDelAndAddPhone;
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
