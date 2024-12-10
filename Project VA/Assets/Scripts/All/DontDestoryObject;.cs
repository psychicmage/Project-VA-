using GLTFast;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DontDestoryObject : MonoBehaviour
{
    public static DontDestoryObject instance = null;
    
    private void Awake()
    {

        var obj = FindObjectsOfType<DontDestoryObject>();
        if (obj.Length == 1)
        {
            Debug.Log("¾À¿¡ 1¸í");
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("ÆÄ±« ¿Ï·á!");
            Destroy(gameObject);
        }

    }
}
