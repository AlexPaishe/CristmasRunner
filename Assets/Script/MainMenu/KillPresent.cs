using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPresent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Gift") || other.CompareTag("Health"))
        {
            other.GetComponent<Desolve>().go = true;
        }
    }
}
