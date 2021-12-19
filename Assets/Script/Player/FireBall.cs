using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float _speed;
    public bool fire;
    private int _direction;
    void Update()
    {
        if (Base.Death == false)
        {
            if (Base.Pause == false)
            {
                if (fire == true)
                {
                    _direction = 1;
                }
                else
                {
                    _direction = -1;
                }
                if (fire == false)
                {
                    transform.position += _direction * Vector3.right * _speed * Base.Speed * Time.deltaTime;
                }
                else
                {
                    transform.position += _direction * Vector3.right * _speed * Base.Speed * Time.deltaTime;
                }

                if (transform.position.x > 60 || transform.position.x < -60)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    /// <summary>
    /// Реализация остановки снежка при контакте
    /// </summary>
    public void Stop()
    {
        _speed = 0;
    }
}
