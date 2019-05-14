using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

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

    public float pitch;
    public float yaw;
    public float roll;
    public float speed = 200.0f;
    public float rotSpeed = 0.75f;
    public float rollSpeed = 50f;

    public float xPosMin = -105.0f;
    public float xPosMax = 120.0f;
    public float zPosMin = -140.0f;
    public float zPosMax = 120.0f;

    public float rotMinMax = 65.0f;


    Quaternion fromRotation;
    Quaternion toRotation;

    public GameObject probe;

    void Update()
    {
        panningControls();
        rotationControls();
        rollControls();
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

    void panningControls()
    {
        float keyboardMoveSpeed = 100.0f;

        if (offPressed == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, Time.deltaTime * keyboardMoveSpeed, Space.World);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, Time.deltaTime * -keyboardMoveSpeed, Space.World);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Time.deltaTime * -keyboardMoveSpeed, 0, 0, Space.World);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Time.deltaTime * keyboardMoveSpeed, 0, 0, Space.World);
            }
        }
        else
        {
            if (upPressed == true)
            {
                transform.Translate(0, 0, Time.deltaTime * 50, Space.World);
            }
            else if (downPressed == true)
            {
                transform.Translate(0, 0, -Time.deltaTime * 50, Space.World);
            }
            else if (leftPressed == true)
            {
                transform.Translate(-Time.deltaTime * 50, 0, 0, Space.World);
            }
            else if (rightPressed == true)
            {
                transform.Translate(Time.deltaTime * 50, 0, 0, Space.World);
            }
        }
        movementLimits();
    }

    void rotationControls()
    {
        if(offPressed == true)
        {
            pitch += Input.GetAxis("Vertical") * rotSpeed;
            yaw += Input.GetAxis("Horizontal") * rotSpeed;
        }
        else
        {
            if (pitchUpPressed == true)
            {
                pitch += 0.5f;
            }
            else if (pitchDownPressed == true)
            {
                pitch -= 0.5f;
            }
            else if (yawLeftPressed == true)
            {
                yaw -= 0.5f;
            }
            else if (yawRightPressed == true)
            {
                yaw += 0.5f;
            }
        }
        transform.localRotation = Quaternion.Euler(pitch, 0, yaw);
        rotationLimits();
    }

    void rollControls()
    {
        if(offPressed == true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                roll = Time.deltaTime * rollSpeed;
                probe.transform.Rotate(-Vector3.up, roll);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                roll = Time.deltaTime * rollSpeed;
                probe.transform.Rotate(Vector3.up, roll);
            }
        }
        else
        {
            if (planeRotCwPressed == true)
            {
                roll += 0.75f;
            }
            else if (planeRotCcwPressed == true)
            {
                roll -= 0.75f;
            }
            probe.transform.localRotation = Quaternion.Euler(0, roll, 0);
        }

    }

    void movementLimits()
    {
        if (transform.position.x >= xPosMax)
        {
            transform.position = new Vector3(xPosMax, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= xPosMin)
        {
            transform.position = new Vector3(xPosMin, transform.position.y, transform.position.z);
        }
        else if (transform.position.z <= zPosMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosMin);
        }
        else if (transform.position.z >= zPosMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosMax);
        }
    }

    void rotationLimits()
    {
        if(transform.localRotation.x >= rotMinMax)
        {
            pitch = rotMinMax;
        }
        else if(transform.localRotation.x <= -rotMinMax)
        {
            pitch = -rotMinMax;
        }
        else if (transform.localRotation.z <= -rotMinMax)
        {
            yaw = -rotMinMax;
        }
        else if (transform.localRotation.z >= rotMinMax)
        {
            yaw = rotMinMax;
        }
    }
}
