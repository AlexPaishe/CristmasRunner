using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUp : MonoBehaviour
{
    private void FixedUpdate()
    {
        for (int i = 0; i < Monocache.allUpdate.Count; i++) Monocache.allUpdate[i].Tick();
    }
}
