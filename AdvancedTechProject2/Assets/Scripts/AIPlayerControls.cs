using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPlayerControls : MonoBehaviour
{
    private NavMeshAgent navmeshagent;
    public GameObject Player;
    public GameObject Door;
    [SerializeField] private Transform[] destination;

    private bool destinationmissing = false;
    public static int current_destination;

    void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(current_destination < destination.Length)
        {
            if (destination[current_destination] != null)
            {
                navmeshagent.SetDestination(destination[current_destination].position);
            }

            else if (destination[current_destination] == null)
            {
                current_destination++;
            }
            destinationmissing = false;
        }
        else
        {
            Debug.Log("issue with path!");
            destinationmissing = true;
        }

        if (destinationmissing)
        {
            current_destination++;
        }      
    }
}
