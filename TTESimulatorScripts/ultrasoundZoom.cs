using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultrasoundZoom : MonoBehaviour {

    public Camera ultrasoundCam;
    float zoom = 100.0f;
    Vector3 initialPos;
    Vector3 camPos;

    void Start()
    {
        initialPos = ultrasoundCam.transform.localPosition;
    }

    void Update()
    {
        zoomControls();
    }

    void zoomControls()
    {
        camPos = ultrasoundCam.transform.localPosition;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            zoom += 10.0f;
            ultrasoundZoomReposition(0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            zoom -= 10.0f;
            ultrasoundZoomReposition(-0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            zoom = 100.0f;
            ultrasoundCam.transform.localPosition = initialPos;
        }

        if (zoom > 150)
        {
            zoom = 150;
            ultrasoundZoomReposition(0);
        }
        else if (zoom < 50)
        {
            zoom = 50;
            ultrasoundZoomReposition(0);
        }

        ultrasoundCam.orthographicSize = zoom;
    }

    void ultrasoundZoomReposition(float zoomModifier)
    {
        ultrasoundCam.transform.localPosition = new Vector3(camPos.x, camPos.y, camPos.z + zoomModifier);
    }
}
