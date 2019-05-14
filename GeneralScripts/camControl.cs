using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour {

    public float speed;
    public float zoomSpeed;

    public float rotHorizon;
    public float rotVertical;

    float zoom;

    public bool xTEEOn;

    public Camera[] mainCam;

    void Update()
    {
        if (!xTEEOn)
        {
          viewController();
        }
        else
        {
            return;
        }
        
    }

    void viewController()
    {
        rotHorizon = Input.GetAxis("Mouse X") * speed;
        rotVertical = Input.GetAxis("Mouse Y") * speed;

        for(int i = 0; i< mainCam.Length; i++)
        {
            if (Input.GetMouseButton(1))
            {
                if (mainCam[0].name == "mainCamTTE")
                {
                    transform.Rotate(Vector3.forward, rotHorizon, Space.World);
                    transform.Rotate(Vector3.right, -rotVertical, Space.Self);
                }
                else if (mainCam[0].name == "mainCamTEE")
                {
                    transform.Rotate(Vector3.up, rotHorizon, Space.World);
                    transform.Rotate(Vector3.forward, -rotVertical, Space.Self);
                }
                else
                {
                    transform.Rotate(Vector3.up, rotHorizon, Space.World);
                    transform.Rotate(Vector3.right, -rotVertical, Space.Self);
                }
            }

            if (Input.GetMouseButton(2))
            {
                mainCam[i].transform.Translate(new Vector3(-rotHorizon * 5, -rotVertical * 5, 0), Space.Self);
            }

            zoom += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
            zoom = Mathf.Clamp(zoom, -45, 20);
            mainCam[i].fieldOfView = 80 + zoom;
        }
    }
}
