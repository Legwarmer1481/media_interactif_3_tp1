using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : MonoBehaviour
{
    private int nbDestinations;
    private int destiIndex = 0;
    private Vector3 direction = Vector3.zero;
    [SerializeField] Vector3[] destinations;
    [SerializeField] float ralentissement = 1f;
    [SerializeField] float interval = 5f;

    // Start is called before the first frame update
    void Start()
    {

        nbDestinations = destinations.Length;
        Invoke("ChangerDirection", interval);
        
    }

    // Update is called once per frame
    void Update()
    {
        Bouge();
    }

    void Bouge(){

        Debug.Log("ok");

        transform.position = Vector3.SmoothDamp(transform.position, destinations[destiIndex], ref direction, ralentissement);

    }

    void ChangerDirection(){

        if(destiIndex == nbDestinations - 1){
            destiIndex = 0;
        }else{
            destiIndex++;
        }

        Invoke("ChangerDirection", interval);
    }
}
