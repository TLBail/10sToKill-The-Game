using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public Vector3 offset;
    [SerializeField] private float scale;
    private void Update() {
        var position = target.position;
        transform.position = new Vector3(position.x, position.y, position.z) + offset;
        offset.x += Input.mouseScrollDelta.y * scale;
    }
}
