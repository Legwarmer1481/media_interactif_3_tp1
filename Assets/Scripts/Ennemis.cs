using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Ennemis : MonoBehaviour
{
    [Header("Cible")]
    [SerializeField] GameObject cible;

    [Header("Caracteristiques")]
    [SerializeField] float vitesse = 2f;

    // Composants
    private UnityEngine.AI.NavMeshAgent agent;

    // Evenements
    public UnityEvent Touche;

    void Start(){

        if (cible == null)
        {
            cible = GameObject.FindGameObjectWithTag("Player");
        }

        agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        //agent.updateUpAxis = false;
        agent.speed = vitesse;
    }

    void Update(){
        agent.SetDestination(cible.transform.position);
    }
}
