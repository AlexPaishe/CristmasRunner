using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPresent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Gift") || other.CompareTag("Health"))
        {
            if(other.GetComponent<Desolve>() != null)
            {
                other.GetComponent<Desolve>().go = true;
            }
            else
            {
                other.GetComponent<Gift>().go = true;
                other.GetComponent<FireBall>().Stop();
            }
        }
        else if(other.CompareTag("Gold"))
        {
            Base.Gold = true;
            other.GetComponent<Gift>().go = true;
            other.GetComponent<FireBall>().Stop();
        }
    }
}
