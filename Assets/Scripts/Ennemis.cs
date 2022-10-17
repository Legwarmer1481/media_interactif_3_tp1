using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Ennemis : MonoBehaviour
{
    [Header("Cibles")]
    [SerializeField] GameObject cible;

    [Header("Audio")]
    [SerializeField] AudioClip explosion;

    [SerializeField] Niveau01 contenu;

    // Composants
    private NavMeshAgent agent;
    private AudioSource audioSource;

    // Contenu de Niveau 01
    [SerializeField] GameObject joueur;
    [SerializeField] PlayerInput joueur_input;
    [SerializeField] JoueurMouvement joueur_mouvement;
    [SerializeField] AudioSource gestionBruit;
    [SerializeField] GameObject defaite;

    void Start(){

        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

        if(contenu == null){
            contenu = GameObject.Find("GestionNiveau").GetComponent<Niveau01>();
            joueur = contenu.joueur;
            joueur_input = contenu.joueur_input;
            joueur_mouvement = contenu.joueur_mouvement;
            gestionBruit = contenu.gestionBruit;
            defaite = contenu.defaite;

            cible = joueur;
        }
    }

    void Update(){

        if(cible != null){
            agent.SetDestination(cible.transform.position);
            agent.speed = 6;
        }
    }

    void OnCollisionEnter(Collision other){

        if(other.transform.tag == "Player"){

            audioSource.Stop();
            gestionBruit.PlayOneShot(explosion, 1.0f);

            joueur_mouvement.SetCursorState(false);
            joueur_input.DeactivateInput();
            defaite.SetActive(true);
            joueur.SetActive(false);

            Destroy(gameObject);
        }

        if(other.transform.tag == "Allie"){

            cible = null;
            agent.ResetPath();

            audioSource.Stop();
            gestionBruit.PlayOneShot(explosion, 1.0f);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
