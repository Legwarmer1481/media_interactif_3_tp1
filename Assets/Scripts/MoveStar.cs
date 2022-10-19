using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStar : MonoBehaviour
{

    [SerializeField] float vitesse = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bouge();
    }

    void Bouge(){

        if(transform.position.z <= -360f){
            transform.position = new Vector3(transform.position.x, transform.position.y, 180f);
        }else{
            transform.position = transform.position - new Vector3(0, 0, vitesse * Time.deltaTime);
        }
    }
}
