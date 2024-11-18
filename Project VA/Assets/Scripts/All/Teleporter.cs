using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleporter : MonoBehaviour
{
    

    public int stage;
    public float position_x;
    public float position_z;
    public float rotation_y;


    public GameObject xrOrigin;
    public FadeScreen fadeScreen;



    private void Awake()
    {
        xrOrigin = GameObject.Find("XR Origin (VR)");
        fadeScreen = GameObject.Find("Fader Screen").GetComponent<FadeScreen>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(NextStage(other));
            

        }
    }

    IEnumerator NextStage(Collider other)
    {
        xrOrigin.GetComponent<ContinuousMoveProviderBase>().enabled = false;
        xrOrigin.GetComponent<SnapTurnProviderBase>().enabled = false;
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(stage);
        other.transform.position = new Vector3(position_x, 0, position_z);
        other.transform.rotation = Quaternion.Euler(0, rotation_y, 0);
        fadeScreen.FadeIn();
        xrOrigin.GetComponent<SnapTurnProviderBase>().enabled = true;
        xrOrigin.GetComponent<ContinuousMoveProviderBase>().enabled = true;
        


    }
}
