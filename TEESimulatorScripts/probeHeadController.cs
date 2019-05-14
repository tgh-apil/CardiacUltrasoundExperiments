using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class probeHeadController : MonoBehaviour
{
    public float pitchSpeed = 1.2f;

    public float pitch;
    public float yaw;
    public float roll;

    public float pitchMin = -35.0f;
    public float pitchMax = 90.0f;

    public float yawMin = -35.0f;
    public float yawMax = 35.0f;

    public bool xTEEOn;

    bool moveOffPressed = true;
    bool twistLeftPressed = false;
    bool twistRightPressed = false;
    bool anteflexPressed = false;
    bool retroflexPressed = false;
    bool yawLeftPressed = false;
    bool yawRightPressed = false;

    void Update()
    {
        flexControl(pitchSpeed);
    }

    public void twistLeft()
    {
        moveOffPressed = false;
        twistLeftPressed = true;
    }

    public void twistRight()
    {
        moveOffPressed = false;
        twistRightPressed = true;
    }

    public void anteflex()
    {
        moveOffPressed = false;
       anteflexPressed = true;
    }

    public void retroflex()
    {
        moveOffPressed = false;
        retroflexPressed = true;
    }

    public void yawLeft()
    {
        moveOffPressed = false;
        yawLeftPressed = true;
    }

    public void yawRight()
    {
        moveOffPressed = false;
        yawRightPressed = true;
    }

    public void moveOff()
    {
        moveOffPressed = true;
        twistLeftPressed = false;
        twistRightPressed = false;
        anteflexPressed = false;
        retroflexPressed = false;
        yawLeftPressed = false;
        yawRightPressed = false;
    }

    public void flexControl(float pitchSpeed)
    {
        if(!xTEEOn)
        {
            if (moveOffPressed == true)
            {
                roll += Input.GetAxis("Horizontal") * -pitchSpeed;
                yaw += Input.GetAxis("Horizontal1") * pitchSpeed;
                pitch += Input.GetAxis("Vertical1") * pitchSpeed;
            }
            else
            {
                if (twistRightPressed == true)
                {
                    roll -= 0.5f * pitchSpeed;
                }
                else if (twistLeftPressed == true)
                {
                    roll += 0.5f * pitchSpeed;
                }
                else if(anteflexPressed == true)
                {
                    pitch += 0.5f * pitchSpeed;
                }
                else if (retroflexPressed == true)
                {
                    pitch -= 0.5f * pitchSpeed;
                }
                else if (yawLeftPressed == true)
                {
                    yaw -= 0.5f * pitchSpeed;
                }
                else if (yawRightPressed == true)
                {
                    yaw += 0.5f * pitchSpeed;
                }
            }
        }
        else if(xTEEOn)
        {
            roll = TEEController.deltaTwist;
            yaw = TEEController.corrLateral;
            pitch = TEEController.corrAnteflex;
        }
        
        if (yaw <= yawMin)
        {
            yaw = yawMin;
        }
        else if(yaw >= yawMax)
        {
            yaw = yawMax;
        }

        if (pitch <= pitchMin)
        {
            pitch = pitchMin;
        }
        else if (pitch >= pitchMax)
        {
            pitch = pitchMax;
        }

        transform.localRotation = Quaternion.Euler(pitch, roll, yaw);
    }
}
