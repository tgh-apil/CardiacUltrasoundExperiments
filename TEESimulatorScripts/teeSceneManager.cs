using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class teeSceneManager : MonoBehaviour {

    public GameObject normalHeart;
    public GameObject pathHeart;
    public GameObject probeParent;
    public GameObject probeHeadPivot;
    public GameObject ultrasoundPlanePivot;
    public GameObject mainCamPivot;
    public Camera mainCamZoom;

    public GameObject heartInfoLabel;
    public GameObject heartSwitchLabel;

    public GameObject homeBtn;
    public GameObject instructionsBtn;
    public GameObject resetCamBtn;
    public GameObject resetProbeBtn;

    public Animator optionsMenuAnim;
    public Animator congenitalMenuAnim;

    Vector3 probeParentInitPos;

    public probeHeadController flexController;
    public camControl cameraController;

    void Start ()
    {
        probeParentInitPos = probeParent.transform.position;
    }

    public void resetCam()
    {
        float horizontalRot = cameraController.rotHorizon = 0.0f;
        float verticalRot = cameraController.rotVertical = 0.0f;

        mainCamPivot.transform.rotation = Quaternion.Euler(horizontalRot, verticalRot, 0);
    }

    public void resetProbe()
    {
        float pitch = flexController.pitch = 0;
        float yaw = flexController.yaw = 0;
        float roll = flexController.roll = 0;

        probeHeadPivot.transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        probeParent.transform.position = probeParentInitPos;
        ultrasoundPlanePivot.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
    }

    public void instructions()
    {
        SceneManager.LoadScene("teeInstructionsScreen");
    }

    public void home()
    {
        SceneManager.LoadScene("cardiacUltrasoundStartScreen");
    }

    public void options()
    {
        if(optionsMenuAnim.GetBool("isOpening") == false)
        {
            optionsMenuAnim.SetBool("isOpening", true);
        }
        else
        {
            optionsMenuAnim.SetBool("isOpening", false);
        }
    }

    public void congenitalSwitch()
    {
        if(congenitalMenuAnim.GetBool("isOpening")== false)
        {
            congenitalMenuAnim.SetBool("isOpening", true);
        }
        else
        {
            congenitalMenuAnim.SetBool("isOpening", false);
        }
    }
}
