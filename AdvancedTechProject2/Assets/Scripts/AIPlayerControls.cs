using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPlayerControls : MonoBehaviour
{
    private NavMeshAgent navmeshagent;

    public GameObject Player;
    public GameObject Door;

    //public GameObject Objectivetext1;
    //public GameObject Objectivetext2;

    [SerializeField] private Transform[] destination;

    public static int current_destination;

    void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        //Objectivetext1.SetActive(false);
        //Objectivetext2.SetActive(false);
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
        }

        Debug.Log("destination " + current_destination);
        Debug.Log("Keys " + KeyCollection.keysCollected);
    }
}
