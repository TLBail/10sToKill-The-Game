using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    GameManager gameManager;

    private List<PointInTime> pointInTimes;
    private Rigidbody rb;

    private void Start() {
        gameManager = GameManager.Instance;
        gameManager.onReverseTime += onReverseTime;
        pointInTimes = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate() {
        if (gameManager.isReversing) {
            Rewind();
        } else {
            Record();
        }
    }

    private void Record() {
        pointInTimes.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    private void Rewind() {
        if (pointInTimes.Count == 0) {
            gameManager.isReversing = false;
            return;
        }

        PointInTime pointInTime = pointInTimes[0];
        transform.position = pointInTime.position;
        transform.rotation = pointInTime.rotation;
        pointInTimes.RemoveAt(0);
    }

    private void onReverseTime() {
        if (gameManager.isReversing) {
            StartRewinding();
        } else {
            StopRewinding();
        }   
    }

    private void StopRewinding() {
        rb.isKinematic = false;
    }

    private void StartRewinding() {
        rb.isKinematic = true;
    }
}
