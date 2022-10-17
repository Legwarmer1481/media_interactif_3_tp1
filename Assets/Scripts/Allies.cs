using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Allies : MonoBehaviour
{

    // Composants
    public GameObject cible;
    public float distance = 5f;
    [SerializeField] private float distanceDefaut = 5f;
    [SerializeField] private SphereCollider detecteur;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(cible != null){

            agent.SetDestination(cible.transform.position);
            agent.stoppingDistance= distance;

        }
        
    }

    void OnCollisionEnter(Collision other){

        if(other.transform.tag == "Player"){

            cible = other.gameObject;
            distance = distanceDefaut;

        }

    }

    
}
