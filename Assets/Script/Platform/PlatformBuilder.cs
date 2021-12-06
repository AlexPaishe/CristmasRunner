using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBuilder : MonoBehaviour
{
    public Transform EndPoint;

    void Start()
    {
        PlatformController.Instance.OnPhoneMovement += TryDelAndAddPhone;
    }

    /// <summary>
    /// Удаление и создание платформы при уходе за определенную зону
    /// </summary>
    private void TryDelAndAddPhone()
    {
        if (transform.position.x < PlatformController.Instance.minX)
        {
            PlatformController.Instance.worldBuilder.CreatPhone();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (PlatformController.Instance != null)
        {
            PlatformController.Instance.OnPhoneMovement -= TryDelAndAddPhone;
        }
    }
}
