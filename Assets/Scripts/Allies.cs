using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Allies : MonoBehaviour
{

    // Composants
    public GameObject cible;
    public float distance = 5;
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
            agent.stoppingDistance = distance;

        }
        
    }

    void OnCollisionEnter(Collision other){

        if(other.transform.tag == "Player"){

            cible = other.gameObject;
            distance = 5f;

        }

    }

    void OnTriggerEnter(Collider other){

        if(other.transform.tag == "Ennemi"){

            cible = other.gameObject;
            distance = 0f;

        }

    }

    
}
