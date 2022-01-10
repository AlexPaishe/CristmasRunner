using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monocache : MonoBehaviour
{
    public static List<Monocache> allUpdate = new List<Monocache>(10001);

    private void OnEnable() => allUpdate.Add(this);

    private void OnDisable() => allUpdate.Remove(this);

    private void OnDestroy() => allUpdate.Remove(this);

    public void Tick() { OnTick(); }

    public virtual void OnTick() { }

}
