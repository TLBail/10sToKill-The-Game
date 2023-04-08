using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BulletController : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float speed = 600f;
    void Start()
    {
        //add force forwand bullet on rigidbody
        rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update() {
        if(!rigidbody.isKinematic)
            rigidbody.velocity = transform.forward * (speed * Time.deltaTime);

    }
}
