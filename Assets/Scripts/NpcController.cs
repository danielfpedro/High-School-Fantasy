using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class NpcController : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;
    public Vector3 target;
    public float desiredVelocity;

    public HeroController heroController;

    // public List<Vector3> nodes;
    // private int currentNodeIndex = 0;
    // public Transform nodesParent;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();

        heroController = GetComponent<HeroController>();
        agent.updateRotation = false;

        // agent.SetDestination(target);

        /**for (int i = 0; i < nodesParent.childCount; i++)
        {
            nodes.Add(nodesParent.GetChild(i).transform.position);
        }
        **/

        // agent.SetDestination(nodes[currentNodeIndex]);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            heroController.Move(agent.desiredVelocity, false, false);
        } else
        {
            Debug.Log("AQUI");
            heroController.Move(Vector3.zero, false, false);
        }
        

        // agent.SetDestination(target.position);
    }

    private void OnDrawGizmos()
    {
        // Gizmos.color = Color.blue;
        // Gizmos.DrawSphere(target, .5f);
    }

}
