using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMainMenu : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnClickNewGame()
    {
        Debug.Log("�� ����");
    }

    public void OnClickLoad()
    {
        LoadingSceneController.LoadScene("2.Dream");
        Debug.Log("����ϱ�");
    }

    public void OnClickOption()
    {
        
        Debug.Log("�ɼ�");
    }


    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
