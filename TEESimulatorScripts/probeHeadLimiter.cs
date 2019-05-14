using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class probeHeadLimiter : MonoBehaviour {

    public probeHeadController flexController;
    float flexMax;

    void Update()
    {
        rayCaster();
    }

    void rayCaster()
    {
        RaycastHit hit;
        flexMax = flexController.pitch;

        if (Physics.Raycast(transform.position, -transform.forward * 100, out hit))
        {
            if (hit.collider.name == "Ah3_Aligned" && hit.distance <= 1.5f)
            {
                flexController.pitchMax = flexMax;
            }
            else
            {
                flexController.pitchMax += Input.GetAxis("Vertical1") * flexController.pitchSpeed;
                if(flexController.pitchMax >= 90.0f)
                {
                    flexController.pitchMax = 90.0f;
                }

                if(flexController.pitchMax <= -35)
                {
                    flexController.pitchMax = -35.0f;
                }
            }
        }
    }
}
