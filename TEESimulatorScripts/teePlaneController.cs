using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teePlaneController : MonoBehaviour {

    public float speed;
    public bool xTEEOn;

    bool moveOffPressed = true;
    bool beamRotateCwPressed = false;
    bool beamRotateCcwPressed = false;

    void Update ()
    {
        controller();
    }

    public void moveOff()
    {
        moveOffPressed = true;
        beamRotateCcwPressed = false;
        beamRotateCwPressed = false;
    }

    public void beamRotateCw()
    {
        moveOffPressed = false;
        beamRotateCwPressed = true;
    }

    public void beamRotateCcw()
    {
        moveOffPressed = false;
        beamRotateCcwPressed = true;
    }

    void controller()
    {
        if (!xTEEOn)
        {
            if(moveOffPressed == true)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    transform.Rotate(Vector3.forward, speed);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    transform.Rotate(Vector3.forward, -speed);
                }
            }
            else
            {
                if(beamRotateCwPressed == true)
                {
                    transform.Rotate(Vector3.forward, -speed);
                }
                else if(beamRotateCcwPressed == true)
                {
                    transform.Rotate(Vector3.forward, speed);
                }
            }

        }
        else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, TEEController.ardOmni * speed));
            
        }

    }
}
