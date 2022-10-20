using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanneauControle : MonoBehaviour
{

    // On viens chercher le minimum qu'on a besoin.
    // Le personnage, ses certains composants, le projecteur près du panneau de contrôle,
    // le scriptableobject pour traquer la progression, le script pour aller à la scène
    // suivante. Le composant Animator de cette objet pour démarrer l'animation. Et 
    // les unityEvents pour gratifier ma paresse.

    [SerializeField] GameObject joueur;
    [SerializeField] GameObject projecteur;
    [SerializeField] JoueurMouvement joueur_mouvement;
    [SerializeField] NiveauProgression progres;
    [SerializeField] GestionScenes scene;
    private Animator anim;
    public UnityEvent activation;
    public UnityEvent aProximite;
    public UnityEvent tropLoin;

    void Start()
    {
        
        anim = GetComponent<Animator>();

    }

    // Le même concepte que la fonction Action() dans les différents scripts.
    // La différence avec les objets interactifs est qu'il active l'animation
    // du levier, force le personnage à regarder le projecteur avant de se téléporter
    // au niveau suivant.
    void Agir(){

        if(joueur_mouvement.action == true){
            
            if(progres.objects[0] == true){

                anim.enabled = true;
                activation.Invoke();

                Invoke("SceneSuivante", 5);

            }
        }
    
    }

    void OnTriggerEnter(Collider other){
    
        if(other.transform.tag == "Player"){
            aProximite.Invoke();
        }
    }

    void OnTriggerExit(Collider other){
        
        if(other.transform.tag == "Player"){
            tropLoin.Invoke();
        }
    }

    void OnTriggerStay(Collider other){

        Debug.Log("Stay" + other.transform.tag);
        
        if(other.transform.tag == "Player"){
            Agir();
        }
    }

    // La méthode appeller par le UnityEvent qui force le joueur à regarder le projecteur
    public void RegarderProjecteur(){

        joueur.transform.LookAt(projecteur.transform);
    }

    void SceneSuivante(){
        scene.SceneSuivante();
    }
}
