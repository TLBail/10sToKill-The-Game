using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingScript : MonoBehaviour
{
    [SerializeField] private string tag = "Bullet";
    public Action actionOnCollision;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(tag)) {
            if (actionOnCollision != null) {
                actionOnCollision?.Invoke();
            } else {
                GameManager.Instance.isRecording = false;
            }
        }
    }

}
