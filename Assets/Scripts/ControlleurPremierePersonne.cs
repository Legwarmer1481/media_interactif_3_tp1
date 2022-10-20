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

    [Space(10)]
    [SerializeField] float actionTimeOut = 0.1f;

    [Header("Joueur au sol")]
    [SerializeField] bool auSol = true;
    [SerializeField] float solOffset = 0.42f;
    [SerializeField] float solCirconference = 0.5f;
    [SerializeField] LayerMask solLayers;

    [Header("Cinemachine")]
    [SerializeField] GameObject cinemachineCameraCible;
    [SerializeField] float topClamp = 90.0f;
    [SerializeField] float bottomClamp = -90.0f;

    // Cinemachine
    private float cinemachineHauteurCible;

    // Joueur
    private float vitesse;
    private float velociteRotation;
    private float velociteVerticale;
    private float velociteTerminale = 53.0f;

    // Minuteries
    private float minuterieSaut;
    private float minuterieChute;
    private float minuterieAction;

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
        SautEtGravite();
        VerificationSol();
        Bouge();
        Agir();
    }

    // Appelle les fonctions en dernier
    void LateUpdate(){
        
        RotationCamera();
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
        Vector3 directionTouche = new Vector3(joueur_mouvement.deplacements.x, 0.0f, joueur_mouvement.deplacements.y).normalized;

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

        joueur_CharacCont.Move(directionTouche.normalized * (vitesse * Time.deltaTime) + new Vector3(0.0f, velociteVerticale, 0.0f) * Time.deltaTime);
    }

    void SautEtGravite(){

        if(auSol){

            minuterieChute = chuteTimeOut;

            if(velociteVerticale < 0.0f){
                velociteVerticale = -2f;
            }

            // Saut
            if(joueur_mouvement.sauter && minuterieSaut <= 0.0f){
                velociteVerticale = Mathf.Sqrt(hauteurSaut * -2f * gravite);
            }

            // Saut minuterie
            if(minuterieSaut >= 0.0f){
                minuterieSaut -= Time.deltaTime;
            }

        }else{

            minuterieSaut = sautTimeOut;

            if(minuterieChute >= 0.0f){
                minuterieChute -= Time.deltaTime;
            }

            joueur_mouvement.sauter = false;
        }

        if(velociteVerticale < velociteTerminale){
            velociteVerticale += gravite * Time.deltaTime;
        }

    }

    void Agir(){
        
        if(joueur_mouvement.action == true){

            if(minuterieAction > 0.0f){
                minuterieAction -= Time.deltaTime;
            }else{
                joueur_mouvement.action = false;
            }


        }else{

            minuterieAction = actionTimeOut;
        
        }
    }

    void RotationCamera(){
        
        if(joueur_mouvement.regarder.sqrMagnitude >= 0.01f){

            float multiplicateurTemps = 1.0f;

            cinemachineHauteurCible += joueur_mouvement.regarder.y * vitesseRotation * multiplicateurTemps;
            velociteRotation = joueur_mouvement.regarder.x * vitesseRotation * multiplicateurTemps;

            cinemachineHauteurCible = ClampAngle(cinemachineHauteurCible, bottomClamp, topClamp);

            cinemachineCameraCible.transform.localRotation = Quaternion.Euler(cinemachineHauteurCible, 0.0f, 0.0f);

            transform.Rotate(Vector3.up * velociteRotation);

        }

    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f) lfAngle += 360f;
			if (lfAngle > 360f) lfAngle -= 360f;
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}


}
