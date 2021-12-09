using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftDrop : MonoBehaviour
{
    [SerializeField] private GameObject[] _present;
    [SerializeField] private Transform _point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("FireBall"))
        {
            int rand = Random.Range(0, 101);
            if(rand > 10)
            {
                rand = 0;
            }
            else
            {
                rand = 1;
            }
            Instantiate(_present[rand], _point.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
