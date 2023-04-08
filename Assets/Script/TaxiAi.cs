using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiAi : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    [SerializeField]
    private Rigidbody rigidbody;
    private void Update() {
        if(!rigidbody.isKinematic)
            rigidbody.velocity = transform.forward * (speed * Time.deltaTime);
    }
}
