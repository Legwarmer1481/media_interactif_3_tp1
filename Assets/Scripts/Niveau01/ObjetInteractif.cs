using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjetInteractif : MonoBehaviour
{

    [SerializeField] NiveauProgression progression;
    [SerializeField] JoueurMouvement joueur_mouvement;

    public UnityEvent aProximite;
    public UnityEvent tropLoin;

    // Update is called once per frame
    void Update()
    {

        Action();
        
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

    void Action(){
        if(joueur_mouvement.action == true){
            
            for(int i = 0; i < progression.objects.Length; i++){
                if(progression.objects[i] == false){
                    
                    progression.objects[i] = true;
                    joueur_mouvement.action = false;
                    tropLoin.Invoke();

                    Destroy(gameObject, 1.0f);
                    break;
                }
            }

        }
    }
}
