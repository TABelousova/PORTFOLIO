using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bot : MonoBehaviour
{
    private GameObject Player;
    private NavMeshAgent Agent;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(Player.transform.position);
        //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Time.deltaTime); 

    }
}
