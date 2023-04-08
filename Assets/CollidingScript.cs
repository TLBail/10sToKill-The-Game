using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingScript : MonoBehaviour
{
    [SerializeField] private string tag = "Bullet";
    public Action actionOnCollision;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag(tag)) {
            actionOnCollision?.Invoke();
        }
    }
}
