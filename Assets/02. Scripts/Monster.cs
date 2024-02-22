using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    public UnityEvent OnEndPointArrived;

    private void OnEnable()
    {
        StartCoroutine(CheckEndPointRoutine());
    }

    public void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }


    IEnumerator CheckEndPointRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        if (CheckEndPoint())
            Destroy(gameObject);
        else
            StartCoroutine(CheckEndPointRoutine());
    }
    private bool CheckEndPoint()
    {
        if (agent.remainingDistance < 0.01f)
        {
            OnEndPointArrived?.Invoke();
            return true;
        }
        else
            return false;
    }
}
