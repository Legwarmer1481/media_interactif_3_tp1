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
        agent.SetDestination(cible.transform.position);
    }

    void OnCollisionEnter(Collision other){

        if(other.transform.tag == "Player"){

            audioSource.Stop();
            audioSource.PlayOneShot(explosion, 1.0f);

            Toucher.Invoke();

            Invoke("AutoDetruire", explosion.length);
        }

    }

    void AutoDetruire(){

            Destroy(gameObject);
    }
}
