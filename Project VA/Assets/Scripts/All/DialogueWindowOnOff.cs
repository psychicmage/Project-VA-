using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWindowOnOff : MonoBehaviour
{
    public GameObject player;
    public Transform playerHead;
    public GameObject dialogue;
    bool isDialogueOn;
    public GameObject semi_dialogue;
    public GameObject button;


    public float talkRange = 3.0f;

    void Start()
    {
        player = GameObject.Find("XR Origin (VR)");
        playerHead = GameObject.Find("Camera Offset").transform;
        isDialogueOn = false;
        semi_dialogue.SetActive(false);
        dialogue.SetActive(false);
        
    }


    // Update is called once per frame
    void Update()
    {
        float distancToPlayer = Vector3.Distance(this.transform.position, player.transform.position);

        if (distancToPlayer <= talkRange)
        {
            dialogue.SetActive(true);
           
            
        }
        else if (distancToPlayer > talkRange) 
        {
            if(isDialogueOn)
            {
                semi_dialogue.SetActive(false);
                button.SetActive(true);
                isDialogueOn = false;
                dialogue.SetActive(false);
            }
            else
            {
                dialogue.SetActive(false);
            }
           
        }
        dialogue.transform.LookAt(new Vector3(playerHead.position.x, dialogue.transform.position.y, playerHead.position.z));
        dialogue.transform.forward *= -1;
    }


    public void DialogeOn()
    {
        isDialogueOn = true;
    }
}
