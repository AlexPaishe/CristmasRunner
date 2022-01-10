using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : Monocache
{
    [SerializeField] private float speed = 10f;

    public WorldBuilder worldBuilder;

    public float minX = -1;

    public delegate void TryToDelAndAddPhone();
    public event TryToDelAndAddPhone OnPhoneMovement;

    public static PlatformController Instance;

    private Transform _tr;

    private void Awake()
    {
        if (PlatformController.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        PlatformController.Instance = this;
        _tr = GetComponent<Transform>();
    }

    private void OnDestroy()
    {
        PlatformController.Instance = null;
    }

    void Start()
    {
        StartCoroutine(OnPhoneMovementCorutine());
    }

    //private void Update()
    //{
    //    if (Base.Death == false)
    //    {
    //        if (Base.Pause == false)
    //        {
    //            _tr.position -= Vector3.right * speed * Base.Speed * Time.deltaTime;
    //        }
    //    }
    //}

    public override void OnTick()
    {
        if (Base.Death == false)
        {
            if (Base.Pause == false)
            {
                _tr.position -= Vector3.right * speed * Base.Speed * Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// ���������� ����� ���������
    /// </summary>
    /// <returns></returns>
    IEnumerator OnPhoneMovementCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (OnPhoneMovement != null)
            {
                OnPhoneMovement();
            }
        }
    }
}
