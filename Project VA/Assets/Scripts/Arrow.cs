using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public Transform tip;


    private Rigidbody _rigidBody;
    private bool _inAir = false;
    private Vector3 _lastPosition = Vector3.zero;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        PullInteraction.PullActionReleased += Release;
    }

    private void OnDestroy()
    {
        PullInteraction.PullActionReleased -= Release;
    }

    void Release(float value)
    {
        PullInteraction.PullActionReleased -= Release;
        gameObject.transform.parent = null;
        _inAir = true;
        //SetPhysics(true);

        Vector3 force = transform.forward * value * speed;
        _rigidBody.AddForce(force, ForceMode.Impulse);
    }
}
