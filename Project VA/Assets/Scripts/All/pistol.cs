using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class pistol : MonoBehaviour
{
    [SerializeField] private GameObject firePos;  //�Ѿ� ���� ��ġ
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
    public void FireBullet(ActivateEventArgs arg)//�Ѿ��� �߻��߾� 
    {
        Debug.Log("�߻�!");
        ad.Play();
        Ray ray = new Ray(firePos.transform.position, firePos.transform.forward * 20); //���̰� ����. 
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1000)) //���� ĳ��Ʈ �Ǿ���(�ε�����) 
        {
            if (hitInfo.collider.tag == "Enemy") //�ٵ� �װ� ���̾� 
            {
                Debug.Log("�� ����!");
                NeutralEnemy.curHealth--;//ü�� ���� 

            }
            else
            {
                Debug.Log("�� ���� ���� �ƴ�!");
            }

        }

    }

    
   

   

    







}
