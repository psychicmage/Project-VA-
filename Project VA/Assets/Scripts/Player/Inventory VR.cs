using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class InventoryVR : MonoBehaviour
{
    public InputActionProperty X_Button;
    public GameObject inventory;
    public GameObject anchor;
    bool UIActive;

    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false); 
        UIActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool XButtonInput = X_Button.action.WasPerformedThisFrame();
        if(XButtonInput)
        {
            Debug.Log("버튼 눌림");
            //버튼입력 코드 작성 
            UIActive = !UIActive;
            inventory.SetActive(UIActive);

            
        }
        if (UIActive)
        {
            inventory.transform.position = anchor.transform.position;
            inventory.transform.eulerAngles = new Vector3(anchor.transform.eulerAngles.x + 15, anchor.transform.eulerAngles.y, 0);
        }



    }
}
