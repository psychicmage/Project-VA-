using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
public class ButtonPush : MonoBehaviour
{
    public bool isClick = false; //버튼 누름 여부 
    public bool isPlatformOn = false; //플레이어가 플랫폼 위에 있는지 여부 
    public GameObject platform;//엘베 
    public GameObject player;//플레이어 
    
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
            
            Debug.Log("올라감");
        }
            
        else if (isClick == false)
        {
            isClick = true;
            Debug.Log("내려감");
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
