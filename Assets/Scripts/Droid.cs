using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : MonoBehaviour
{

    // Un objet se déplace automatiquement.
    // Le développeur peut écrire les destinations sur l'éditeur Unity
    // pour indiquer à l'objet assigné d'aller à ses destinations une à
    // la fois. Il peut contrôler le temps pour arriver la destination et
    // le temps d'interval avant de changer de destination.

    private int nbDestinations;
    private int destiIndex = 0;
    private Vector3 direction = Vector3.zero;
    private Transform parent;
    private float minuterie;
    [SerializeField] Vector3[] destinations;
    [SerializeField] float ralentissement = 1f;
    [SerializeField] float interval = 5f;

    void Start()
    {

        // Puisque le développeur peut mettre un nombre infini de destinations,
        // on a besoin de savoir combien il y en a. On prend note du parent de
        // l'objet pour faire éviter des problèmes avec les positions locales et 
        // globales. On commence le script qui fait changer de cible à l'interval
        // décidé par le développeur.

        nbDestinations = destinations.Length;
        parent = transform.parent;
        minuterie = ralentissement;
        Invoke("ChangerDirection", interval);
        
    }

    void Update()
    {
        Bouge();
    }

    // D'abord, les destinations sont normalements sous forme local dans l'inspecteur de l'objet, mais la
    // fonction TransformPoint a besoin des coordonnées globales. Alors, on converti les destinations locales
    // écritent par le créateur de jeux en globales en utilisant le parent de l'objet comme point central.
    // Ensuite, l'objet se déplace sans de soucis.
    // On diminue la minuterie pour garder la vitesse constante.
    void Bouge(){

        Vector3 destination = parent.transform.TransformPoint(destinations[destiIndex]);

        transform.position = Vector3.SmoothDamp(transform.position, destination, ref direction, minuterie);

        minuterie -= Time.deltaTime;

    }

    // L'objet change de destination. Quand l'index dépasse le nombre de destinations disponibles, il se remet à 0.
    // Il se rappelle elle-même pour faire l'interval.
    void ChangerDirection(){

        if(destiIndex == nbDestinations - 1){
            destiIndex = 0;
        }else{
            destiIndex++;
        }

        minuterie = ralentissement;

        Invoke("ChangerDirection", interval);
    }
}
