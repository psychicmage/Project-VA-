
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;
    public Image slotImage;
    Color originalColor;

    //XR툴킷용 
    public InputActionProperty rightGripButton;


    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (ItemInSlot != null)
            return;
        GameObject obj = other.gameObject;
        if (!IsItem(obj))
            return;
        ////GetUp 구현 
        bool gripButtonReleased = rightGripButton.action.WasPerformedThisFrame();
        if (gripButtonReleased)
        {
            Debug.Log("손을 놨다가 땜! ");
            InsertItem(obj);
        }
        
    }

    

    private bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    public void InsertItem(GameObject obj)
    {
        
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = obj.GetComponent<Item>().slotPosition;//Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
        obj.GetComponent<Item>().isSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        ItemInSlot = obj;
        slotImage.color = Color.gray;



    }

    public void ResetColor()
    {
        slotImage.color = originalColor;
    }

}
