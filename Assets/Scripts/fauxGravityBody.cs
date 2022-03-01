using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fauxGravityBody : MonoBehaviour {
    
    public FauxGravityAttractor attractor;
    private Transform myTransform;
   
    void Start () {

        attractor = GameObject.Find("Planet").GetComponent<FauxGravityAttractor>();

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
 //       myTransform = transform;
	}
	
	void FixedUpdate () {
       attractor.Attract(transform);
	}


    
}
