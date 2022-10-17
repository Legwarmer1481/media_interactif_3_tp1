using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesDetecteur : MonoBehaviour
{

    [SerializeField] Allies allie;

    void OnTriggerEnter(Collider other){

        Debug.Log(other.transform.tag);

        if(allie.cible != null && allie.cible.transform.tag == "Player"){

            if(other.transform.tag == "Ennemi"){

                allie.cible = other.gameObject;
                allie.distance = 0;

            }

        }

    }
}
