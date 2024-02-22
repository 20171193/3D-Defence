using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private LayerMask groundLM;

    [SerializeField]
    private NavMeshAgent agent;

    [Header("Ballancing")]
    [SerializeField]
    [ReadOnly(false)]
    private Transform endPoint;

    [SerializeField]
    private Vector3 mousePos;



    private void OnRightClick(InputValue value)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,  out RaycastHit hitInfo))
        {
            Move(hitInfo.point);
        }
    }
    private void Move(Vector3 point)
    {
        agent.destination = point;
    }


    private void Start()
    {
        
    }
}
