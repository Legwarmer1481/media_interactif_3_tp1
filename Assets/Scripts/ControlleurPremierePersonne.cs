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
    [SerializeField] float vitesseChangement = 10.0f;

    [Space(10)]
    [SerializeField] float hauteurSaut = 1.2f;
    [SerializeField] float gravite = -15.0f;

    [Space(10)]
    [SerializeField] float sautTimeOut = 0.1f;
    [SerializeField] float chuteTimeOut = 0.1f;

    [Header("Joueur au sol")]
    [SerializeField] bool auSol = true;
    [SerializeField] float solOffset = 0.42f;
    [SerializeField] float solCirconference = 0.5f;
    [SerializeField] LayerMask solLayers;

    [Header("Cinemachine")]
    [SerializeField] GameObject cinemachineCameraCible;
    [SerializeField] float topClamp = 90.0f;
    [SerializeField] float bottomClamp = -90.0f;

    // Joueur
    private float vitesse;
    private float velociteRotation;
    private float velociteVerticale;
    private float velociteTerminale = 53.0f;

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

        VerificationSol();
        Bouge();
        /*
            1. Saut et Gravite
            2. Verifier si le personnage touche le sol
        */  
    }

    void LateUpdate(){
        /* 
            Rotation de caméra
         */
    }

    // Verifier si le personnage touche le sol
    void VerificationSol(){
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - solOffset, transform.position.z);
		auSol = Physics.CheckSphere(spherePosition, solCirconference, solLayers, QueryTriggerInteraction.Ignore);
    }

    // Gerer mouvement
    void Bouge(){
        
        float vitesseCible;
        float vitesseHorizontal = new Vector3(joueur_CharacCont.velocity.x, 0.0f, joueur_CharacCont.velocity.z).magnitude;
        float vitesseOffset = 0.1f;
        Vector3 directionTouche = new Vector3(joueur_mouvement.deplacements.x, 0.0f, joueur_mouvement.deplacements.y);

        if(joueur_mouvement.courir == true){
            vitesseCible = vitesseCourse;
        }else{
            vitesseCible = vitesseMarche;
        }
        if(joueur_mouvement.deplacements == Vector2.zero){
            vitesseCible = 0.0f;
        }

        if(vitesseHorizontal < vitesse - vitesseOffset || vitesseHorizontal > vitesse + vitesseOffset){
            
            vitesse = Mathf.Lerp(vitesseHorizontal, vitesseCible, Time.deltaTime * vitesseChangement);
        
            vitesse = Mathf.Round(vitesse * 1000f) / 1000f;
        }else{
            vitesse = vitesseCible;
        }

        if(joueur_mouvement.deplacements != Vector2.zero){
            directionTouche = transform.right * joueur_mouvement.deplacements.x + transform.forward * joueur_mouvement.deplacements.y;
        }

        joueur_CharacCont.Move(directionTouche.normalized * (vitesse * Time.deltaTime) + new Vector3(0.0f, 0.0f, 0.0f) * Time.deltaTime);
    }


}
