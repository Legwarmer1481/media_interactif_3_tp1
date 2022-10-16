using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Ennemis : MonoBehaviour
{
    [Header("Cible")]
    [SerializeField] GameObject cible;

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

        Debug.Log(agent);
    }

    void Update(){
        agent.SetDestination(cible.transform.position);
    }
}
