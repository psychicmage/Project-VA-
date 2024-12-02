using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //ü�� 
    public float health;
    public float maxHealth;

    //�÷��̾� �ǰ� ���� 

    CharacterController cc;
    bool isDamage;
    public Image damageImage;


    //�÷��̾� UI
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
    /// �÷��̾��� �ǰ� ������ 
    /// </summary>
    /// <param name="other"></param>



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.tag == "Enemy")
        {
            Debug.Log("����!");
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
        Debug.Log("������ �޴� ��");
        damageImage.enabled = true;
        yield return new WaitForSeconds(1f);

        isDamage = false;
        damageImage.enabled = false;
    }

    
}
