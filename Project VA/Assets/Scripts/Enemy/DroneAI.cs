using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class DroneAI : MonoBehaviour
{

    



    
    public float idleDelayTime = 2;
    float currentTime;
    public static bool isDamaged;

    public float moveSpeed = 1;
    Transform player;
    NavMeshAgent agent;

    public float attackRange = 3;

    public float attackDelayTime = 2;

    [SerializeField] int hp = 3;





    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("XR Origin (VR)").transform;
        agent = GetComponent<NavMeshAgent>();
       // agent.enabled = false;
        agent.speed = moveSpeed;
        isDamaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDamaged)
        {

            agent.SetDestination(player.position);
            if (Vector3.Distance(transform.position, player.position) < attackRange)
            {
                currentTime += Time.deltaTime;
                if (currentTime > attackDelayTime)
                {
                    Debug.Log("공격 받음!");
                    currentTime = 0;
                }

            }
        }

        
    }

    
    
  

    public void OnDamageProcess()
    {
        hp--;
        if(hp > 0)
        {
            StopAllCoroutines();
            StartCoroutine(Damage());
        }
        else
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Damage()
    {
        agent.enabled = false;
        Material mat = GetComponentInChildren<MeshRenderer>().material;
        Color originalColor = mat.color;
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        mat.color = originalColor;
        agent.enabled = true;
        currentTime = 0;



    }
}
