using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveau01 : MonoBehaviour
{

    [SerializeField] NiveauProgression np;
    [SerializeField] JoueurMouvement joueur_controle;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < np.objects.Length; i++){
            np.objects[i] = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
