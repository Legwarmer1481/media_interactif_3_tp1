using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanneauControle : MonoBehaviour
{

    [SerializeField] GameObject joueur;
    [SerializeField] GameObject projecteur;
    [SerializeField] JoueurMouvement joueur_mouvement;
    [SerializeField] NiveauProgression progres;
    [SerializeField] GestionScenes scene;
    private Animator anim;
    public UnityEvent activation;
    public UnityEvent aProximite;
    public UnityEvent tropLoin;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();

    }

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

    public void RegarderProjecteur(){

        joueur.transform.LookAt(projecteur.transform);
    }

    void SceneSuivante(){
        scene.SceneSuivante();
    }
}
