using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCLifeController : MonoBehaviour {

    private NavMeshAgent agent;
    // private HeroController heroController;

    public GameObject nodes;
    private Transform currentNode;
    public int currentNodeIndex = 0;
    private int totalNodes;

    // Use this for initialization
    void Start () {
        currentNode = nodes.transform.GetChild(currentNodeIndex);
        agent = GetComponent<NavMeshAgent>();

        // heroController = GetComponent<HeroController>();
        // agent.updateRotation = false;

        totalNodes = nodes.transform.childCount;

        Move();
    }
	
	// Update is called once per frame
	void Update () {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            // heroController.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            GoToNextNode();
            Move();
            // heroController.Move(Vector3.zero, false, false);
        }
    }

    private void GoToNextNode()
    {
        if (currentNodeIndex >= (totalNodes - 1))
        {
            currentNodeIndex = 0;
        } else
        {
            currentNodeIndex++;
        }
        currentNode = nodes.transform.GetChild(currentNodeIndex);
    }

    private void Move()
    {
        agent.SetDestination(currentNode.position);
    }
}
