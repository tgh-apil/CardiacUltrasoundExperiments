using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenController : MonoBehaviour {

    public GameObject probe;
    public GameObject ultrasoundPlane;
    public float pitch;
    public float yaw;
    public float roll;

    bool upPressed = false;
    bool downPressed = false;
    bool leftPressed = false;
    bool rightPressed = false;
    bool offPressed = true;

    bool pitchUpPressed = false;
    bool pitchDownPressed = false;
    bool yawLeftPressed = false;
    bool yawRightPressed = false;
    bool planeRotCwPressed = false;
    bool planeRotCcwPressed = false;

    void Update()
    {
        if (offPressed != true)
        {
            onScreenMovement();
            onScreenRotation();
        }
        else
        {
            return;
        }
    }

    public void moveUp()
    {
        offPressed = false;
        upPressed = true;
    }

    public void moveDown()
    {
        offPressed = false;
        downPressed = true;
    }

    public void moveLeft()
    {
        offPressed = false;
        leftPressed = true;
    }

    public void moveRight()
    {
        offPressed = false;
        rightPressed = true;
    }

    public void pitchUp()
    {
        offPressed = false;
        pitchUpPressed = true;
    }

    public void pitchDown()
    {
        offPressed = false;
        pitchDownPressed = true;
    }

    public void yawLeft()
    {
        offPressed = false;
        yawLeftPressed = true;
    }

    public void yawRight()
    {
        offPressed = false;
        yawRightPressed = true;
    }

    public void planeRotCw()
    {
        offPressed = false;
        planeRotCwPressed = true;
    }

    public void planeRotCcw()
    {
        offPressed = false;
        planeRotCcwPressed = true;
    }

    public void moveOff()
    {
        offPressed = true;
        upPressed = false;
        downPressed = false;
        leftPressed = false;
        rightPressed = false;
        pitchUpPressed = false;
        pitchDownPressed = false;
        planeRotCwPressed = false;
        planeRotCcwPressed = false;
        yawLeftPressed = false;
        yawRightPressed = false;
    }


    void onScreenMovement()
    {
        if(upPressed == true)
        {
            probe.transform.Translate(0, 0, Time.deltaTime * 50, Space.World);
        }
        else if (downPressed == true)
        {
            probe.transform.Translate(0, 0, -Time.deltaTime * 50, Space.World);
        }
        else if (leftPressed == true)
        {
            probe.transform.Translate(-Time.deltaTime * 50, 0, 0, Space.World);
        }
        else if (rightPressed == true)
        {
            probe.transform.Translate(Time.deltaTime * 50, 0, 0, Space.World);
        }
    }

    void onScreenRotation()
    {     
        if (pitchUpPressed == true)
        {
            pitch += 0.2f;
            probe.transform.localRotation = Quaternion.Euler(pitch, roll, yaw);
        }
        else if(pitchDownPressed == true)
        {
            pitch -= 20;
            probe.transform.localRotation = Quaternion.Euler(pitch, roll, yaw);
        }
        else if(yawLeftPressed == true)
        {
            yaw -= 20;
            probe.transform.localRotation = Quaternion.Euler(pitch, roll,  yaw);
        }
        else if (yawRightPressed == true)
        {
            yaw += 0.5f;
            probe.transform.localRotation = Quaternion.Euler(pitch, roll, yaw);
            print(probe.transform.localRotation.z);
        }
        else if (planeRotCwPressed == true)
        {
            roll += 0.5f;
            ultrasoundPlane.transform.localRotation = Quaternion.Euler(0, roll, 0);
        }
        else if (planeRotCcwPressed == true)
        {
            roll -= 0.5f;
            ultrasoundPlane.transform.localRotation = Quaternion.Euler(0, roll, 0);
        }


    }
}
