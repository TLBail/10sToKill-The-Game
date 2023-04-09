using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionWall : MonoBehaviour
{

    [SerializeField] private Transform explosionPosition;
    public List<Rigidbody> rigidbodiesInchildrens;

    private void Start() {
        rigidbodiesInchildrens = new List<Rigidbody>();
        foreach (Transform child in transform) {
            if (child.TryGetComponent(typeof(Rigidbody), out var rb)) {
                rigidbodiesInchildrens.Add((Rigidbody)rb);
            }
        }
    }

    public void explosion() {
        foreach (Rigidbody rg in rigidbodiesInchildrens) {
            rg.useGravity = true;
            rg.AddExplosionForce(60000f, explosionPosition.position, 10);
        }
        
    }
}
