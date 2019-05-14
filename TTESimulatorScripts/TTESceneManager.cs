using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TTESceneManager : MonoBehaviour
{
    public Controller probeController;

    public Transform ultrasoundParent;
    public Transform ultrasoundPlane;

    public Transform mainCamPivot;

    public GameObject normalHeart;
    public GameObject pathHeart1;
    public GameObject lungs;
    public GameObject ribs;
    public GameObject chest;

    public GameObject probe;
    public GameObject probeParent;

    public GameObject xRotLabel;
    public GameObject yRotLabel;
    public GameObject zRotLabel;
    public GameObject scanningDepthLabel;
    public GameObject loadHeartLabel;
    public GameObject heartInfoLabel;
    public GameObject lungBtn;
    public GameObject ribsBtn;
    public GameObject chestBtn;

    public Animator optionsPanelAnim;

    public Camera ultrasoundCam;

    Text xRotText;
    Text yRotText;
    Text zRotText;
    Text scanningDepthText;
    Text loadHeartText;
    Text heartInfoText;
    Text lungText;
    Text ribsText;
    Text chestText;

    void Start()
    {
        xRotText = xRotLabel.GetComponentInChildren<Text>();
        yRotText = yRotLabel.GetComponentInChildren<Text>();
        zRotText = zRotLabel.GetComponentInChildren<Text>();
        
        loadHeartText = loadHeartLabel.GetComponentInChildren<Text>();
        heartInfoText = heartInfoLabel.GetComponentInChildren<Text>();
        lungText = lungBtn.GetComponentInChildren<Text>();
        ribsText = ribsBtn.GetComponentInChildren<Text>();
        chestText = chestBtn.GetComponentInChildren<Text>();

        heartInfoText.text = "Full size patient heart with no pathologies.\n3D model segmented from CT dataset and segmented with ITK-SNAP";
    }

    void Update ()
    {
        ultrasoundUI();		
	}

    void ultrasoundUI()
    {
        float xRotValue = ultrasoundParent.transform.localEulerAngles.x;
        float yRotValue = ultrasoundPlane.transform.localEulerAngles.y;
        float zRotValue = ultrasoundParent.transform.localEulerAngles.z;

        float depthlevel = (ultrasoundCam.orthographicSize - 100) / 10;

        if (xRotValue > 180)
        {
            xRotValue = (xRotValue - 360) * - 1;
        }
        else
        {
            xRotValue = -xRotValue;
        }

        if (yRotValue > 180)
        {
            yRotValue = yRotValue - 360;
        }

        if (zRotValue > 180)
        {
            zRotValue = zRotValue - 360;
        }

        xRotText.text = "Superior to Inferior Tilt: " + xRotValue.ToString("F2") + "°";
        yRotText.text = "Right to Left Tilt: " + zRotValue.ToString("F2") + "°";
        zRotText.text = "Beam Rotation: " + yRotValue.ToString("F2") + "°";

        
    }

    public void resetProbe()
    {
        float pitch = probeController.pitch = 0;
        float yaw = probeController.yaw = 0;

        probe.transform.position = new Vector3(0, 201, -50);
        probe.transform.localRotation = Quaternion.Euler(pitch, 0, yaw);
        ultrasoundPlane.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void loadHeart()
    {
        if(loadHeartText.text == "Load Normal Heart")
        {
            normalHeart.SetActive(true);
            pathHeart1.SetActive(false);
            loadHeartText.text = "Load Pathology";
            heartInfo(0);
        }
        else if(loadHeartText.text == "Load Pathology")
        {
            normalHeart.SetActive(false);
            pathHeart1.SetActive(true);
            loadHeartText.text = "Load Normal Heart";
            heartInfo(1);
        }
    }

    public void resetCamera()
    {
        mainCamPivot.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }


    public void home()
    {
        SceneManager.LoadScene("cardiacUltrasoundStartScreen");
    }

    public void instructions()
    {
        SceneManager.LoadScene("tteInstructionsScreen");
    }

    void heartInfo(int heartNum)
    {
        if(heartNum == 0)
        {
            heartInfoText.text = "Full size patient heart with no pathologies.  3D model segmented from CT dataset and segmented with ITK-SNAP";
        }
        else if(heartNum == 1)
        {
            heartInfoText.text = "Full size patient heart with <color=#D5271EFF><b>aortic dissection</b></color>.\nThe dissection runs from the aortic arch through the descending aorta.\n3D model segmented from CT dataset and segmented with ITK-SNAP";
        }
    }

    public void lungsDisplay()
    {
        if(lungText.text == "Hide Lungs")
        {
            lungText.text = "Display Lungs";
            lungs.SetActive(false);
        }
        else if(lungText.text == "Display Lungs")
        {
            lungText.text = "Hide Lungs";
            lungs.SetActive(true);
        }
    }

    public void ribsDisplay()
    {
        if (ribsText.text == "Hide Ribs")
        {
            ribsText.text = "Display Ribs";
            ribs.SetActive(false);
        }
        else if (ribsText.text == "Display Ribs")
        {
            ribsText.text = "Hide Ribs";
            ribs.SetActive(true);
        }
    }

    public void chestDisplay()
    {
        if (chestText.text == "Hide Chest")
        {
            chestText.text = "Display Chest";
            chest.SetActive(false);
        }
        else if (chestText.text == "Display Chest")
        {
            chestText.text = "Hide Chest";
            chest.SetActive(true);
        }
    }

    public void optionsMenu()
    {
        if(optionsPanelAnim.GetBool("isOpening") == true)
        {
            optionsPanelAnim.SetBool("isOpening", false);
        }
        else
        {
            optionsPanelAnim.SetBool("isOpening", true);
        }
    }





}
