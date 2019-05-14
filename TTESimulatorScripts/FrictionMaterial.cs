using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionMaterial : MonoBehaviour {

    public Collider col;
    

    void Start ()
    {
        PhysicMaterial friction = new PhysicMaterial();
        friction.dynamicFriction = 1;
        
        col = GetComponent<Collider>();
        col.material = friction;
    }

}
