using UnityEngine;
using UnityEngine.AI;

public class AgentAI : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private Transform pointA, pointB;

    [SerializeField] private bool destinationReached;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(pointA.position);
        destinationReached = false;
    }

    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Debug.Log("1");
            //checks velocity of our agent has stopped
            if (agent.velocity.sqrMagnitude == 0)
            {
                Debug.Log("2");

                //checks if the agent has no path
                if (!agent.hasPath)
                {
                    Debug.Log("3");

                    if (!agent.pathPending)
                    {
                        destinationReached = true;
                        agent.SetDestination(pointB.position);
                        destinationReached = false;
                    }
                }
            }
        }
    }
}
