using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZoneChambreFort : MonoBehaviour
{
    public UnityEvent dialogue;

    // Fait apparaître une bulle de monologue géré par le UnityEvent

    void OnTriggerEnter(Collider other){

        if(other.transform.tag == "Player"){

            dialogue.Invoke();
            Destroy(gameObject);
        }


    }
}
