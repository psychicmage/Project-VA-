using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    //ü�� 
    public float health;
    public float maxHealth;

    //�÷��̾� �ǰ� ���� 
    bool isDamage;
    public bool isDead;
    public Image damageImage;
    public CharacterController cc;


    //�÷��̾� �κ��丮 
    public InventoryVR inventoryVR;
    public GameObject inventory;

    public GameObject weapon;


    //�÷��̾� UI
    public Slider HpBarSlider;
    string sceneName;
    public Text mapName;



    void Awake()
    {
        health = maxHealth;
        HpBarSlider.value = (float)health / (float)maxHealth;

        damageImage.enabled = false;

        cc = GetComponent<CharacterController>();

        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Quest_Gun_Level 1"))
        {
            weapon = GameObject.Find("Quest_Gun_Level 1");
        }
        else
        {
            weapon = null;
        }
        sceneName  = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);

        mapName.text = "��:"+sceneName;
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
            if(!isDamage && !isDead)
            {
                DroneAI drone = hit.collider.GetComponent<DroneAI>();
                health -= drone.damage;
                StartCoroutine(OnDamage());

            }
            
        }
    }

    IEnumerator OnDamage()
    {
        if (health <= 0 && !isDead)
        {
            isDamage = true;
            OnDie();
            yield return new WaitForSeconds(1f);
            isDamage = false;
            
        }
        else
        {
            isDamage = true;
            damageImage.enabled = true;
            yield return new WaitForSeconds(1f);
            isDamage = false;
            damageImage.enabled = false;
        }
        

    }

    void OnDie()
    {
        if(weapon != null)
        {
            weapon.SetActive(false);
        }
        if(inventoryVR.enabled == true)
        {
            inventory.SetActive(false); 
            inventoryVR.enabled = false;
        }
        
        isDead = true;
        damageImage.enabled = true;
        GameManager.Instance.GameOver();
    }








}
