using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonScript : MonoBehaviour
{
    [SerializeField]
    private List<Transform> positionsGoals;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    
    private void Start() {
        agent.destination = positionsGoals[0].position;
        agent.speed = 3f;
        agent.acceleration = 8f;
        agent.angularSpeed = 120f;
        agent.enabled = true;
        agent.stoppingDistance = 1f;
    }

    private void Update() {
        
        bool shouldMove = agent.velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        // Update animation parameters
        animator.SetBool("isWalking", shouldMove);

    }
}
