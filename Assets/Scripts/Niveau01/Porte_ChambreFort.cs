using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte_ChambreFort : MonoBehaviour
{

    [SerializeField] NiveauProgression progres;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Detruire(){
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other){

        if(other.transform.tag == "Player"){

            if(progres.objects[0] == true){

                anim.enabled = true;

            }

        }

    }
}
