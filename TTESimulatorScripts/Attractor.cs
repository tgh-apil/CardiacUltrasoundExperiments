using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    public float gravity = -500; 

    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
    }

}
