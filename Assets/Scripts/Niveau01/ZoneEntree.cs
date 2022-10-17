using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZoneEntree : MonoBehaviour
{
    
    [SerializeField] Animator porte_anim;
    [SerializeField] private GameObject ennemis;

    public UnityEvent dialogue;

    void OnTriggerEnter(Collider other){

        if(other.transform.tag == "Player"){
            porte_anim.SetBool("character_nearby", false);

            dialogue.Invoke();

            Destroy(ennemis);
            Destroy(gameObject);
        }

    }
}
