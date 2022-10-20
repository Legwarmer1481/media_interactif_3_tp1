using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicateur_Rotate : MonoBehaviour
{

    // L'objet tourne sur elle-même
    [SerializeField] float vitesse = 5;

    void Update()
    {
        Tourne();
    }

    void Tourne(){

        transform.Rotate(0, 0, vitesse * Time.deltaTime, Space.Self);
    }
}
