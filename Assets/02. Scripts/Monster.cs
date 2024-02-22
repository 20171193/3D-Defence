using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    public void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }
}