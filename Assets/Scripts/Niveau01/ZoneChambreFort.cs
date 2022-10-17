using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZoneChambreFort : MonoBehaviour
{
    public UnityEvent dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){

        if(other.transform.tag == "Player"){

            dialogue.Invoke();
            Destroy(gameObject);
        }


    }
}
