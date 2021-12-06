using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        transform.position += Vector3.right * _speed * Base.Speed * Time.deltaTime;
    }
}
