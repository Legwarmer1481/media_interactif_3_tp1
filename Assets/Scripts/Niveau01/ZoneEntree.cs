using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZoneEntree : MonoBehaviour
{
    
    [SerializeField] Animator porte_anim;

    public UnityEvent enSecurite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){

        porte_anim.SetBool("character_nearby", false);

        enSecurite.Invoke();

    }
}
