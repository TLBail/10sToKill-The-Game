using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAi : MonoBehaviour
{
    //UnityEditor.TransformWorldPlacementJSON:{"position":{"x":17.721181869506837,"y":26.18548583984375,"z":-299.1175231933594},"rotation":{"x":0.23231784999370576,"y":-0.7234529852867127,"z":-0.07500379532575607,"w":-0.6457698345184326},"scale":{"x":2.617500066757202,"y":2.617500066757202,"z":2.617500066757202}}
    private Rigidbody rigidbody;
    private Vector3 targetPosition = new Vector3(17.7f, 26.18f, -299.11f);
    [SerializeField]
    private float speed = 100f;
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate() {
        if(!rigidbody.isKinematic)
            rigidbody.velocity =  transform.forward *speed;
            
    }

}
