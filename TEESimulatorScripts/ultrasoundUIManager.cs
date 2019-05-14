using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ultrasoundUIManager : MonoBehaviour
{
    public GameObject probeParent;
    public GameObject probeHead;
    public GameObject ultrasoundPlane;
    public Camera ultrasoundCam;

    public GameObject depthLabel;
    public GameObject anteflexLabel;
    public GameObject flexLabel;
    public GameObject rotateLabel;
    public GameObject beamRotateLabel;
    
    
    Vector3 initPos;

    Text depthText;
    Text anteflexText;
    Text flexText;
    Text rotateText;
    Text beamRotateText;
    

	void Start ()
    {
        depthText = depthLabel.GetComponentInChildren<Text>();
        anteflexText = anteflexLabel.GetComponentInChildren<Text>();
        flexText = flexLabel.GetComponentInChildren<Text>();
        rotateText = rotateLabel.GetComponentInChildren<Text>();
        beamRotateText = beamRotateLabel.GetComponentInChildren<Text>();
        

        initPos = probeParent.transform.position;
    }
	
	void Update ()
    {
        ultrasoundUI();
	}

    void ultrasoundUI()
    {
        float anteflex = probeHead.transform.localEulerAngles.x;
        float flex = probeHead.transform.localEulerAngles.z;
        float probeRotation = probeHead.transform.localEulerAngles.y;
        float beamRotation = ultrasoundPlane.transform.localEulerAngles.z;
        float scanDepth = (ultrasoundCam.orthographicSize - 100)/10;
        float deltaY = Mathf.Abs(probeParent.transform.position.y - initPos.y);
        float deltaZ = Mathf.Abs(probeParent.transform.position.z - initPos.z);

        float depthGauge = (deltaY + deltaZ)/10;

        if (anteflex > 180)
        {
            anteflex = anteflex - 360;
        }

        if (flex > 180)
        {
            flex = flex - 360;
        }

        if (probeRotation > 180)
        {
            probeRotation = probeRotation - 360;
        }

        if (beamRotation > 180)
        {
            beamRotation = beamRotation - 360;
        }

        depthText.text = "Probe Depth: " + depthGauge.ToString("F2") + " units.";
        anteflexText.text = "Anteflextion: " + anteflex.ToString("F2") + "°";
        flexText.text = "Left to Right Flexion: " + flex.ToString("F2") + "°";
        rotateText.text = "Probe Rotation: " + probeRotation.ToString("F2") + "°";
        beamRotateText.text = "Beam Rotation: " + beamRotation.ToString("F2") + "°";
        
    }
}
