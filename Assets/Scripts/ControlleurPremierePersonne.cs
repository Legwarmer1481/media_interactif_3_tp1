using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlleurPremierePersonne : MonoBehaviour
{

    [Header("Joueur")]
    [SerializeField] float vitesseMarche = 1.0f;
    [SerializeField] float vitesseCourse = 3.0f;
    [SerializeField] float vitesseRotation = 1.0f;

    [Space(10)]
    [SerializeField] float HauteurSaut = 1.2f;
    [SerializeField] float Gravite = -15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
