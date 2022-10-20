using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte_ChambreFort : MonoBehaviour
{

    [SerializeField] NiveauProgression progres;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        
    }

    // Cette méthode est appellé par l'animation pour faire disparaître la porte
    // quand l'animation est fini
    public void Detruire(){
        Destroy(gameObject);
    }

    // Active l'animation qui fait ouvrir la porte quand le personnage se trouve à proximité
    // de la porte avec la carte d'accès
    void OnTriggerEnter(Collider other){

        if(other.transform.tag == "Player"){

            if(progres.objects[0] == true){

                anim.enabled = true;

            }

        }

    }
}
