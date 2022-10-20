using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjetInteractif : MonoBehaviour
{

    // Les objets interactifs ont besoin d'avoir accès au scriptableObject
    // afin de pouvoir vérifier si le joueur a les objets qu'il faut.
    // Il a besoin du script JoueurMouvement pour avoir de pouvoir vérifier
    // si le joueur a appuyé sur la touche Q pour interagir avec l'objet.

    [SerializeField] NiveauProgression progression;
    [SerializeField] JoueurMouvement joueur_mouvement;

    // Je suis trop paresseux pour écrire le code à la main qui fait apparaître
    // et disparaître la bulle qui encourage à appuyer sur Q. Je fait appel à
    // UnityEvent pour faire ce travail pour moi.

    public UnityEvent aProximite;
    public UnityEvent tropLoin;

    // Quand le personnage entre dans la sphère collider, la bulle apparait

    void OnTriggerEnter(Collider other){
        
        if(other.transform.tag == "Player"){
            aProximite.Invoke();
        }
    }

    // Quand le personnage est reste dans la sphère collider parce qu'il n'a rien
    // a faire, ça appel la fonction Action() à tous les frames. C'est comme update,
    // mais à condition que l'objet reste dans le trigger collider quelque chose.
    // Je vais expliquer à quoi la fonction Action() fait dans pas long

    void OnTriggerStay(Collider other){

        Action();
    
    }

    // Je vous la laisse deviner, après avoir vu les deux autres avant, ça devrait être
    // évidant. Cette fonction fait disparaître la bulle qui propose de peser sur Q.

    void OnTriggerExit(Collider other){
        
        if(other.transform.tag == "Player"){
            tropLoin.Invoke();
        }

    }

    // C'est simple, quand le joueur appuie sur Q. L'objet à proximité va disparaître et
    // ça va mettre la progression dans le scriptableObject pour marquer que le joueur à
    // rempli une condition

    void Action(){
        if(joueur_mouvement.action == true){
            
            for(int i = 0; i < progression.objects.Length; i++){
                if(progression.objects[i] == false){
                    
                    progression.objects[i] = true;
                    joueur_mouvement.action = false;
                    tropLoin.Invoke();

                    Destroy(gameObject, 1.0f);
                    break; // On ne veux pas que ça coche à tous les listes de conditions. On arrête quand une condition est rempli.
                }
            }

        }
    }
}
