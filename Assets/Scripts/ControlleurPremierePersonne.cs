using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlleurPremierePersonne : MonoBehaviour
{

    [Header("Joueur")]
    [SerializeField] float vitesseMarche = 1.0f;
    [SerializeField] float vitesseCourse = 3.0f;
    [SerializeField] float vitesseRotation = 1.0f;

    [Space(10)]
    [SerializeField] float hauteurSaut = 1.2f;
    [SerializeField] float gravite = -15.0f;

    [Space(10)]
    [SerializeField] float sautTimeOut = 0.1f;
    [SerializeField] float chuteTimeOut = 0.1f;

    [Header("Cinemachine")]
    [SerializeField] GameObject cinemachineCameraCible;
    [SerializeField] float topClamp = 90.0f;
    [SerializeField] float bottomClamp = -90.0f;


    // Composants
    private PlayerInput joueur_input;
    private CharacterController joueur_CharacCont;
    private GameObject cameraPrincipal;
    private JoueurMouvement joueur_mouvement;
    
    void Awake(){
        if(cameraPrincipal == null){
            cameraPrincipal = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    void Start()
    {

        joueur_CharacCont = GetComponent<CharacterController>();
        joueur_input = GetComponent<PlayerInput>();
        joueur_mouvement = GetComponent<JoueurMouvement>();
        
    }

    void Update()
    {
        /* 4 fonctions:
            1. Saut et Gravite
            2. Verifier si le personnage touche le sol
            3. Se deplace
            4. Rotation de caméra
        */  
    }

    // Gerer mouvement

    void Bouge(){
        
        float vitesse;
        float vitesseHorizontal = new Vector3(joueur_CharacCont.velocity.x, 0.0f, joueur_CharacCont.velocity.z).magnitude;
        float vitesseOffset = 0.1f;


        if(joueur_mouvement.courir == true){
            vitesse = vitesseCourse;
        }else{
            vitesse = vitesseMarche;
        }
        if(joueur_mouvement == Vector2.zero){
            vitesse = 0.0f;
        }

        if(vitesseHorizontal < vitesse - vitesseOffset || vitesseHorizontal > vitesse + vitesseOffset){
            
        }
    }


}
