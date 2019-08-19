using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AgentController : MonoBehaviour
{
    public bool UseMouseControll = false;
    public Camera Cam;
    public Transform[] PatrolPoints;

    private int currentControlPointIndex = 0;
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

    private void Start()
    {
        character = GetComponent<ThirdPersonCharacter>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        MoveToNextPatrolPoint();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextPatrolPoint();
        }
        if (UseMouseControll)
        {
            MouseControll();
        }

        if(agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }

    private void MoveToNextPatrolPoint()
    {
        agent.destination = PatrolPoints[currentControlPointIndex].position;
        currentControlPointIndex++;
        currentControlPointIndex %= PatrolPoints.Length;
    }
    private void MouseControll()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
