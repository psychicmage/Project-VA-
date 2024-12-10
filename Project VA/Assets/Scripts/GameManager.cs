using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public Player playerScript;
    public GameObject player;
    public GameObject onPlayerDeadUI;
    public GameObject backButton;

    public float position_x;
    public float position_z;
    public float rotation_y;

    public GameObject xrOrigin;
    public FadeScreen fadeScreen;

    


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);


        //xrOrigin = GameObject.Find("XR Origin (VR)");
        //fadeScreen = GameObject.Find("Fader Screen").GetComponent<FadeScreen>();
        //player = GameObject.Find("Player").GetComponent<Transform>();   
        player = GameObject.Find("XR Origin (VR)");
        onPlayerDeadUI.SetActive(false);
        backButton.SetActive(false);


    }

    private void Update()
    {
            
    }

    public void GameOver()
    {
        playerScript.cc.enabled = false;
        xrOrigin.GetComponent<ContinuousMoveProviderBase>().enabled = false;
        xrOrigin.GetComponent<SnapTurnProviderBase>().enabled = false;
        onPlayerDeadUI.SetActive(true);
        backButton.SetActive(true);
        
    }

    public void Restart()
    {
        
        StartCoroutine(GameRestart());
    }


    public IEnumerator GameRestart()
    {
        playerScript.damageImage.enabled = false;
        backButton.SetActive(false);
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("3.Town");
        player.transform.position = new Vector3(position_x, 0, position_z);
        player.transform.rotation = Quaternion.Euler(0, rotation_y, 0);
        onPlayerDeadUI.SetActive(false);
        fadeScreen.FadeIn();
        
        playerScript.isDead = false;
        playerScript.cc.enabled = true;
        
        playerScript.health = playerScript.maxHealth;

        xrOrigin.GetComponent<ContinuousMoveProviderBase>().enabled = true;
        xrOrigin.GetComponent<SnapTurnProviderBase>().enabled = true;
        playerScript.inventoryVR.enabled = true;

    }


   

  
    


}
