using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Utils 
{
    [MenuItem("Utils/ClearPlayerPrefs")]
    public static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clear PlayerPrefs!");
    }
}
