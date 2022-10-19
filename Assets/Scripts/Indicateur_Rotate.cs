using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicateur_Rotate : MonoBehaviour
{

    private Vector3 orientationDepart;
    [SerializeField] float vitesse = 5;

    // Start is called before the first frame update
    void Start()
    {

        orientationDepart = transform.localEulerAngles;
        
    }

    // Update is called once per frame
    void Update()
    {
        Tourne();
    }

    void Tourne(){

        transform.Rotate(0, 0, vitesse * Time.deltaTime, Space.Self);
    }
}
