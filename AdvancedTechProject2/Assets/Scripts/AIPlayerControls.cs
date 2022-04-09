using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIPlayerControls : MonoBehaviour
{
    private NavMeshAgent navmeshagent;
    public GameObject Player;
    public GameObject Door;
    [SerializeField] private Transform[] destination;

    private bool destinationmissing = false;
    public static int current_destination;

    [SerializeField] private Text destinationText;

    void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();

        destinationText.text = "Current Destination: 0/11";
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

        if(current_destination <= 11)
        {
            destinationText.text = "Current Destination: " + current_destination + "/11";
        }
    }
}
