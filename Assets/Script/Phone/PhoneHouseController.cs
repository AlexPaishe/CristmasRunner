using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneHouseController : Monocache
{
    [SerializeField] private float speed = 10f;

    public PhoneHouseBuilder phoneHouseBuilder;

    public float minX = -1;

    public delegate void TryToDelAndAddPhone();
    public event TryToDelAndAddPhone OnPhoneMovement;

    public static PhoneHouseController Instance;

    private Transform _tr;

    private void Awake()
    {
        if (PhoneHouseController.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        PhoneHouseController.Instance = this;
        _tr = GetComponent<Transform>();
    }

    private void OnDestroy()
    {
        PhoneHouseController.Instance = null;
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
    /// Вычесление новой платформы
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
