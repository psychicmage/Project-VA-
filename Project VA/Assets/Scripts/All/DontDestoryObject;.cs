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
            Debug.Log("���� 1��");
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("�ı� �Ϸ�!");
            Destroy(gameObject);
        }

    }
}
