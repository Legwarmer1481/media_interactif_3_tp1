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

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {

        // À chaque frame, le robot qui vous protège cherche sa cible
        // gérer par le NavMesh. Un moment donné, la variable cible
        // ne sera plus null, mais contiendra un gameObjet. Quand
        // ça arrivera, il va la suivre ou foncer dedans selon la valeur
        // attribuée à stoppingDistance.

        if(cible != null){

            agent.SetDestination(cible.transform.position);
            agent.stoppingDistance = distance;

        }
        
    }

    // Le joueur fonce dessus le robot gentil. Il sera suivi par ce dernier.
    void OnCollisionEnter(Collision other){

        if(other.transform.tag == "Player"){

            cible = other.gameObject;
            distance = 5f;

        }

    }

    // Quand l'ennemi se trouve dans le périmètre assigné. Il se sacrifira pour te protéger.
    // Comment oses-tu lui faire ça !!
    void OnTriggerEnter(Collider other){

        if(other.transform.tag == "Ennemi" && cible.transform.tag == "Player"){

            cible = other.gameObject;
            distance = 0f;

        }

    }

    
}
