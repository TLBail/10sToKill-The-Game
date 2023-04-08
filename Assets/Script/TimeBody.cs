using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TimeBody : MonoBehaviour
{
    GameManager gameManager;

    private List<PointInTime> pointInTimes;
    private Rigidbody rb;
    [SerializeField]
    public List<Component> componentsToDesactivate;

    [SerializeField] private NavMeshAgent agent;

    private void Start() {
        gameManager = GameManager.Instance;
        gameManager.onRecordTime += onRecordTime;
        pointInTimes = new List<PointInTime>();
        if(TryGetComponent(typeof(Rigidbody), out var rbb)) this.rb = (Rigidbody)rbb;

        onRecordTime();
    }


    private void FixedUpdate() {
        if (gameManager.isRecording) {
            Record();
        } else {
            updateBody();
        }

    }

    private void Record() {
        if(!gameManager.isRecording) return;
        if (pointInTimes.Count > Math.Round((1f / Time.fixedDeltaTime)) * 20f) {
            pointInTimes.RemoveAt(pointInTimes.Count - 1);
        }
        pointInTimes.Insert(0, new PointInTime(transform.position, transform.rotation));

    }

    private void updateBody() {
        if (gameManager.timeIndex >= pointInTimes.Count -1) {
            gameManager.isPlayingRecord = 0;
            gameManager.timeIndex--;
            return;
        }

        PointInTime pointInTime = pointInTimes[gameManager.timeIndex];
        transform.position = pointInTime.position;
        transform.rotation = pointInTime.rotation;
    }

    private void onRecordTime() {
        if (gameManager.isRecording) {
            StartRecording();
        } else {
            StopRecording();
        }   
    }

    private void StopRecording() {
        if(rb != null)
            rb.isKinematic = true;
        if(agent != null)
            agent.isStopped = true;
    }

    private void StartRecording() {
        if(rb != null)
            rb.isKinematic = false;
        if(agent != null)
            agent.isStopped = false;
    }
}
