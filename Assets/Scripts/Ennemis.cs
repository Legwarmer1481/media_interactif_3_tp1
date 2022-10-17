using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Ennemis : MonoBehaviour
{
    [Header("Cibles")]
    [SerializeField] GameObject cible;

    [Header("Audio")]
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioSource gestionSon;

    // Composants
    private NavMeshAgent agent;
    private AudioSource audioSource;

    // Evenements
    public UnityEvent Toucher;

    void Start(){

        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update(){

        if(cible != null){
            agent.SetDestination(cible.transform.position);
        }
    }

    void OnCollisionEnter(Collision other){

        if(other.transform.tag == "Player"){

            audioSource.Stop();
            gestionSon.PlayOneShot(explosion, 1.0f);

            Toucher.Invoke();

            Destroy(gameObject);
        }

        if(other.transform.tag == "Allie"){

            cible = null;
            agent.ResetPath();

            audioSource.Stop();
            gestionSon.PlayOneShot(explosion, 1.0f);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
