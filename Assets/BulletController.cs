using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BulletController : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float speed = 600f;
    Vector3 vectorTowardTarget;
    void Start()
    {
        //add force forwand bullet on rigidbody
        rigidbody = GetComponent<Rigidbody>();
    }


    public void updateVector() {
        vectorTowardTarget = GameManager.Instance.impactPosition - transform.position;
        vectorTowardTarget.Normalize();
    }

    private void Update() {
        if(!rigidbody.isKinematic)
            rigidbody.velocity =  vectorTowardTarget * (speed * Time.deltaTime);

    }
}
