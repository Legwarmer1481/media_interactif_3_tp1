using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Niveau01 : MonoBehaviour
{

    // Ce script est responable à maintenir les informations nécessaire pour
    // permettre aux robots méchants de fonctionner correctement.
    // Ce script fait apparaître les ennemis à des endroit aléatoires du monde.

    [SerializeField] NiveauProgression np;
    private GameObject[] spawns;
    [SerializeField] GameObject Ennemi;
    [SerializeField] GameObject Ennemis;

    [Header("Ennemis")]
    public GameObject joueur;
    public PlayerInput joueur_input;
    public JoueurMouvement joueur_mouvement;
    public AudioSource gestionBruit;
    public GameObject defaite;


    void Start()
    {
        joueur_mouvement.SetCursorState(joueur_mouvement.cursorLocked);

        for(int i = 0; i < np.objects.Length; i++){
            np.objects[i] = false;
        }

        np.ennemiTotal = 0;

        spawns = GameObject.FindGameObjectsWithTag("Spawn");

        PoperEnnemi();
        
    }

    void PoperEnnemi(){

        if(np.ennemiTotal < np.ennemiMax){

            int i = Random.Range(0, spawns.Length);
            Vector3 emplacement = spawns[i].transform.position;

            GameObject nouvelEnnemi = Instantiate(Ennemi, emplacement, Quaternion.identity);
            nouvelEnnemi.transform.parent = Ennemis.transform;
            np.ennemiTotal++;

            Invoke("PoperEnnemi", 5);
        }
    }
}
