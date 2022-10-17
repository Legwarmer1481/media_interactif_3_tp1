using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoueurMouvement : MonoBehaviour
{

    [Header("Valeurs de mouvement")]
    public Vector2 deplacements;
    public Vector2 regarder;
    public bool sauter;
    public bool courir;
    public bool action;

    [Header("Mouse Cursor Settings")]
	public bool cursorLocked = true;
	public bool cursorInputForLook = true;

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

    public void OnAction(InputValue value){
        Action(value.isPressed);
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

    public void Action(bool etat){
        action = etat;
    }

    /* ================================================
        Le focus de la souris à l'appli
    ================================================ */

    private void OnApplicationFocus(bool hasFocus)
	{
		SetCursorState(cursorLocked);
	}

	public void SetCursorState(bool newState)
	{
		Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
	}
}
