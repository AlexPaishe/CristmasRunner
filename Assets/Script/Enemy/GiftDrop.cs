using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftDrop : MonoBehaviour
{
    [SerializeField] private GameObject[] _present;
    [SerializeField] private Transform _point;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("FireBall"))
        {
            int rand = Random.Range(0, 101);
            if (Base.Hard == false)
            {
                if (rand > 10)
                {
                    rand = 0;
                }
                else
                {
                    rand = 1;
                }
            }
            else
            {
                rand = 0;
            }
            Instantiate(_present[rand], _point.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
