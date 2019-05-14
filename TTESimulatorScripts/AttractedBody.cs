using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractedBody : MonoBehaviour {

    public Attractor attractor;
    Transform myTransform;
    Rigidbody rb;

	void Start ()
    {
        myTransform = transform;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
	}

	void Update ()
    {
        attractor.Attract(myTransform);	
	}
}
