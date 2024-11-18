using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NeutralEnemy : MonoBehaviour
{
    public Transform head;
    public GameObject hp;
    public Image gauge;
    public static float curHealth; //* 현재 체력
    public float maxHealth; //* 최대 체력 

    private void Start()
    {
        curHealth = maxHealth;
    }


    void Update()
    {
        hp.transform.LookAt(new Vector3(head.position.x, hp.transform.position.y, hp.transform.forward.z));
        hp.transform.forward *= -1;

        gauge.fillAmount = GetPercentage();

        if (curHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    float GetPercentage()
    {
        return curHealth / maxHealth;
    }
}
