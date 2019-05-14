using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teeProbeController : MonoBehaviour {

    float advSpeed;
    float retSpeed;
    public float speed = 1.2f;
    float dist = 100.0f;
    Vector3 targetNormal;
    public bool xTEEOn;
    float startingHeight;

    bool moveOffPressed;
    bool advancePressed = false;
    bool retractPressed = false;

    void Start()
    {
        xTEEOn = false;
        startingHeight = transform.position.y;
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward * dist, out hit))
        {
            targetNormal = hit.normal;
            rotateToForward();
        }
        advanceWithdraw();
    }

    public void advance()
    {
        moveOffPressed = false;
        advancePressed = true;
    }

    public void retract()
    {
        moveOffPressed = false;
        retractPressed = true;
    }

    public void moveOff()
    {
        moveOffPressed = true;
        advancePressed = false;
        retractPressed = false;
    }

    void rotateToForward()
    {
        Quaternion fromToRotation = transform.rotation;
        Quaternion toRotation = Quaternion.FromToRotation(-Vector3.forward, targetNormal);
        transform.rotation = Quaternion.Slerp(fromToRotation, toRotation, 0.1f);
    }

    void advanceWithdraw()
    {
        positionLimits();

        if (!xTEEOn)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.up * advSpeed, Space.Self);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * retSpeed, Space.Self);
            }
        }
        else
        {
            //only for the laser -- DO NOT USE
            //transform.localPosition = new Vector3(transform.position.x, startingHeight - TEEController.deltaDist * 3, transform.position.z);
            
            float adv = Input.GetAxis("Mouse Y");
            transform.Translate(Vector3.up * adv * 3.0f, Space.Self);
        }

        if (moveOffPressed == true)
        {
            return;
        }
        else
        {
            if(advancePressed == true)
            {
                transform.Translate(Vector3.up * advSpeed, Space.Self);
            }
            else if(retractPressed == true)
            {
                transform.Translate(Vector3.up * retSpeed, Space.Self);
            }
        }
    }

    void positionLimits()
    {
        if (transform.position.y >= 180.0f)
        {
            advSpeed = -speed;
            retSpeed = 0;
        }
        else if (transform.position.z <= -85.0f)
        {
            advSpeed = 0;
            retSpeed = speed;
        }
        else
        {
            advSpeed = -speed;
            retSpeed = speed;
        }
    }
}
