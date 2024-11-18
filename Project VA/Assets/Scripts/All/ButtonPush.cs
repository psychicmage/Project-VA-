using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
public class ButtonPush : MonoBehaviour
{
    public bool isClick = false; //��ư ���� ���� 
    public bool isPlatformOn = false; //�÷��̾ �÷��� ���� �ִ��� ���� 
    public GameObject platform;//���� 
    public GameObject player;//�÷��̾� 
    
    public Transform aPos;
    public Transform bPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => Toggle());
    }

    public void Toggle()
    {
        if (isClick == true)
        {
            isClick = false;
            
            Debug.Log("�ö�");
        }
            
        else if (isClick == false)
        {
            isClick = true;
            Debug.Log("������");
        }
            
    }

    void FixedUpdate()
    {
        if (isClick == true) 
        {
            if (!isPlatformOn)
            {
                player.transform.SetParent(platform.transform);
                isPlatformOn = true;
            }

            platform.transform.position = Vector3.MoveTowards(platform.transform.position, aPos.position, Time.fixedDeltaTime * speed);
            if (platform.transform.position == aPos.position)
            {
                player.transform.SetParent(null);
                isPlatformOn = false;
            }
                


        }

        else if (isClick == false)
        {
            if (!isPlatformOn)
            {
                player.transform.SetParent(platform.transform);
                isPlatformOn = true;
            }

            platform.transform.position = Vector3.MoveTowards(platform.transform.position, bPos.position, Time.fixedDeltaTime * speed);
            if (platform.transform.position == bPos.position)
            {
                player.transform.SetParent(null);
                isPlatformOn = false;
            }
                
        }
    }


}
