using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemGrabbable : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    public void Grab()
    {

        if (gameObject.GetComponent<Item>() == null)
        {
            return;
        }
        if (gameObject.GetComponent<Item>().isSlot)
        {
           
            //gameObject.transform.parent = null;
            gameObject.GetComponent<Item>().isSlot = false;
            gameObject.GetComponent<Item>().currentSlot.ResetColor();
            gameObject.GetComponent<Item>().currentSlot = null;
            
        }
    }
    public void Release()
    {
        if(gameObject.transform.parent != null ) 
        {
            gameObject.GetComponentInParent<Slot>().ItemInSlot = null;
            gameObject.transform.parent = null;
        }
        if (gameObject.GetComponent<Rigidbody>().isKinematic == true)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

   
}
