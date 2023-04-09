using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoffreAi : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void dropCoffre() {
        if (!rigidbody.isKinematic) {
            rigidbody.AddExplosionForce(10000f, transform.position + new Vector3(0,0,-5), 10);
        }
    }
    
}
