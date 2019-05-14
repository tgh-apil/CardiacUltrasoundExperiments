using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xTEEController : MonoBehaviour
{
    public GameObject xTEEBtn;
    public GameObject xTEEWarningPanel;
    public GameObject xTEEInstructions;
    public GameObject TEEControllerManager;

    public Animator optionsMenuAnim;
    public Animator controllerPanelAnim;

    bool xTEEOn;
    Text xTEEText;
    Text xTEEInstructionsText;

    void Start()
    {
        xTEEText = xTEEBtn.GetComponentInChildren<Text>();
        xTEEInstructionsText = xTEEInstructions.GetComponentInChildren<Text>();

        xTEEText.text = "Activate xTEE";
        xTEEInstructionsText.text = "<b>(1)</b> Position the holder near the edge of your table. \n<b>(2)</b> Fully retract the xTEE's handle.\n<b>(3)</b> After pressing <b><color=#00FF76FF>Okay</color></b>, place your mouse into the holder.\n<b>(4)</b>To return to keyboard controls, press <b>ESCAPE on your keyboard</b>.";
        xTEEOn = false;
    }

    void Update()
    {
        if(xTEEOn == true)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                xTEEText.text = "Activate xTEE";
                xTEEOn = false;
                toggleControls(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                xTEEBtn.SetActive(true);
                controllerPanelAnim.SetBool("isClosing", false);
                TEEControllerManager.SetActive(false);
            }
        }
    }

    public void xTEEActivateButton()
    {
        xTEEWarningPanel.SetActive(false);
        toggleControls(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        xTEEBtn.SetActive(false);
        TEEControllerManager.SetActive(true);
        controllerPanelAnim.SetBool("isClosing", true);
    }

    public void xTEECancelButton()
    {
        xTEEOn = false;
        toggleControls(false);
        xTEEWarningPanel.SetActive(false);
        TEEControllerManager.SetActive(false);
    }

    public void xTEEOnToggle()
    {
        if (!xTEEOn)
        {
            xTEEOn = true;
            TEEControllerManager.SetActive(true);
            xTEEWarningPanel.SetActive(true);
            optionsMenuAnim.SetBool("isOpening", false);
        }
    }

    void toggleControls(bool activated)
    {
        GameObject.Find("mainCamPivot").GetComponent<camControl>().xTEEOn = activated;
        GameObject.Find("teeProbeParent").GetComponent<teeProbeController>().xTEEOn = activated;
        GameObject.Find("probeHeadPivot").GetComponent<probeHeadController>().xTEEOn = activated;
        GameObject.Find("ultrasoundPlanePivot").GetComponent<teePlaneController>().xTEEOn = activated;
        GameObject.Find("teeSceneManager").GetComponent<teeSceneManager>().resetProbe();
        GameObject.Find("teeSceneManager").GetComponent<teeSceneManager>().resetCam();
    }
}
