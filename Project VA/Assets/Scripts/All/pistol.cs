using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class pistol : MonoBehaviour
{
    [SerializeField] private GameObject firePos;  //총알 생성 위치
    [SerializeField] AudioSource ad;
    [SerializeField] 
    bool isBulletHit;
    // Start is called before the first frame update
    void Start()
    {
        ad = GetComponent<AudioSource>();
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }
    public void FireBullet(ActivateEventArgs arg)//총알을 발사했어 
    {
        Debug.Log("발사!");
        ad.Play();
        Ray ray = new Ray(firePos.transform.position, firePos.transform.forward * 20); //레이가 나감. 
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1000)) //레이 캐스트 되었어(부딪혔어) 
        {
            if (hitInfo.collider.tag == "Enemy") //근데 그게 적이야 
            {
                Debug.Log("적 조준!");
                NeutralEnemy.curHealth--;//체력 감소 

            }
            else
            {
                Debug.Log("적 조준 상태 아님!");
            }

        }

    }

    
   

   

    







}
