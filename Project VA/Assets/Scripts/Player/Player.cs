using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //체력 
    public float health;
    public float maxHealth;

    //플레이어 피격 관련 

    CharacterController cc;
    bool isDamage;
    public Image damageImage;


    //플레이어 UI
    public Slider HpBarSlider;


    void Awake()
    {
        health = maxHealth;
        cc = GetComponent<CharacterController>();
        damageImage.enabled = false;    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HpBarSlider.value = (float)health / (float)maxHealth;
    }


    /// <summary>
    /// 플레이어의 피격 데미지 
    /// </summary>
    /// <param name="other"></param>



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.tag == "Enemy")
        {
            Debug.Log("명중!");
            if(!isDamage)
            {
                DroneAI drone = hit.collider.GetComponent<DroneAI>();
                health -= drone.damage;
                StartCoroutine(OnDamage());
            }
        }
    }

    IEnumerator OnDamage()
    {
        isDamage = true;
        Debug.Log("데미지 받는 중");
        damageImage.enabled = true;
        yield return new WaitForSeconds(1f);

        isDamage = false;
        damageImage.enabled = false;
    }

    
}
