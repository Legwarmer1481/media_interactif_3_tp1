using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoueurMouvement : MonoBehaviour
{

    [Header("Valeurs de mouvement")]
    [SerializeField] Vector2 deplacements;
    [SerializeField] Vector2 regarder;
    [SerializeField] bool sauter;
    [SerializeField] bool courir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* ================================================
        Recevoir les signaux des touches de claviers
        et de souris appuyées
    ================================================ */

    public void OnMove(InputValue value){
        Bouge(value.Get<Vector2>());
    }

    public void OnLook(InputValue value){
        Regarder(value.Get<Vector2>());
    }

    public void OnJump(InputValue value){
        Sauter(value.isPressed);
    }

    public void OnSprint(InputValue value){
        Courir(value.isPressed);
    }

    /* ================================================
        Outputer le movement dans
        la fenêtre propriété
    ================================================ */

    public void Bouge(Vector2 nouvelleDirection){
        deplacements = nouvelleDirection;
    }

    public void Regarder(Vector2 nouvelleHorizon){
        regarder = nouvelleHorizon;
    }

    public void Sauter(bool etat){
        sauter = etat;
    }

    public void Courir(bool etat){
        courir = etat;
    }
}
