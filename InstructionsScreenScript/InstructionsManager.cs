using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsManager : MonoBehaviour {

    public GameObject nextBtn;
    public GameObject prevBtn;
    public GameObject textField;
    public GameObject instructionsCounterField;
    public GameObject onScreenControlImg;
    public GameObject instructionObj;

    string[] instructText;

    public Animator instructionsAnim;

    Text instructions;
    Text instructionsCounter;

    int animPos = 0;

    void Start()
    {
        instructions = textField.GetComponentInChildren<Text>();
        instructionsCounter = instructionsCounterField.GetComponentInChildren<Text>();

        animPos = 0;
        buttonsOnOff(false, true);

        instructions.text = "Use <color=#2E81DBFF><b>'W'</b></color> to move the probe forwards <color=#2E81DBFF><i>towards the head</i></color> and <color=#FFE300FF><b>'S'</b></color> to move the probe <color=#FFE300FF><i>backwards towards the feet</i></color>.";
        instructionsCounter.text = animPos+1 + "<b>/6</b>";

        if(instructionsAnim.name == "TTE_simulator_instructions_anim")
        {
            instructText = new string[] { "Use <color=#2E81DBFF><b>'W'</b></color> to move the probe forwards <color=#2E81DBFF><i>towards the head</i></color> and <color=#FFE300FF><b>'S'</b></color> to move the probe <color=#FFE300FF><i>backwards towards the feet</i></color>.",
                                         "Use <color=#2E81DBFF><b>'A'</b></color> to move the probe <color=#2E81DBFF><i>left</i></color> and <color=#FFE300FF><b>'D'</b></color> to move the probe <color=#FFE300FF><i>right</i></color>.",
                                         "Use <color=#2E81DBFF><b>'Q'</b></color> to rotate the probe <color=#2E81DBFF><i>counter-clockwise</i></color> and <color=#FFE300FF><b>'E'</b></color> to rotate the <color=#FFE300FF><i>probe clockwise</i></color>.",
                                         "Use the <color=#2E81DBFF><b>Up Arrow Key</b></color> to tilt the probe <color=#2E81DBFF><i>downwards</i></color> and use the <color=#FFE300FF><b>Down Arrow Key</b></color> to tilt the probe <color=#FFE300FF><i>upwards</i></color>.",
                                         "Use the <color=#2E81DBFF><b>Left Arrow Key</b></color> to tilt the probe <color=#2E81DBFF><i>left</i></color> and use the <color=#FFE300FF><b>Right Arrow Key</b></color> to tilt the probe <color=#FFE300FF><i>right</i></color>.",
                                         "Alternatively, you can click on the <color=#FFE300FF><b>on-screen controls</b></color> to manipulate the probe."};
        }
        else if(instructionsAnim.name == "TEE_simulator_instructions_anim")
        {
            instructText = new string[] { "Use <color=#2E81DBFF><b>'W'</b></color> to <color=#2E81DBFF><i>anteflex the probe</i></color> and <color=#FFE300FF><b>'S'</b></color> to <color=#FFE300FF><i>retroflex the probe</i></color>.",
                                         "Use <color=#2E81DBFF><b>'A'</b></color> to flex the probe <color=#2E81DBFF><i>left</i></color> and <color=#FFE300FF><b>'D'</b></color> to flex the probe <color=#FFE300FF><i>right</i></color>.",
                                         "Use <color=#2E81DBFF><b>'Q'</b></color> to rotate the beam plane <color=#2E81DBFF><i>counter-clockwise</i></color> and <color=#FFE300FF><b>'E'</b></color> to rotate the beam plane <color=#FFE300FF><i>clockwise</i></color>.",
                                         "Use the <color=#2E81DBFF><b>Up Arrow Key</b></color> to <color=#2E81DBFF><i>retract the probe</i></color> and use the <color=#FFE300FF><b>Down Arrow Key</b></color> to <color=#FFE300FF><i>advance the probe</i></color>.",
                                         "Use the <color=#2E81DBFF><b>Left Arrow Key</b></color> to twist the probe <color=#2E81DBFF><i>left</i></color> and use the <color=#FFE300FF><b>Right Arrow Key</b></color> to twist  the probe <color=#FFE300FF><i>right</i></color>.",
                                         "Alternatively, you can click on the <color=#FFE300FF><b>on-screen controls</b></color> to manipulate the probe."};
        }
    }

    public void next()
    {
        animPos += 1;
        instructionsTexts();
    }

    public void prev()
    {
        animPos -= 1;
        instructionsTexts();
    }

    void instructionsTexts()
    {
        instructionsAnim.SetInteger("animPos", animPos);

        instructions.text = instructText[animPos];
        instructionsCounter.text = animPos+1 + "<b>/6</b>";

        if (animPos == 0)
        {
            buttonsOnOff(false, true);
        }
        else if(animPos == 1)
        {
            buttonsOnOff(true, true);
        }
        else if (animPos == 4)
        {
            instructionsCounter.text = animPos+1 + "<b>/6</b>";
            buttonsOnOff(true, true);
            onScreenControlImg.SetActive(false);
            instructionObj.layer = 0;
        }
        else if(animPos == 5)
        {
            instructionsCounter.text = "<color=#D5271EFF><b>6/6</b></color>";
            buttonsOnOff(true, false);
            onScreenControlImg.SetActive(true);
            instructionObj.layer = 14;
        }

    }

    void buttonsOnOff(bool prevOn, bool nextOn)
    {
        prevBtn.SetActive(prevOn);
        nextBtn.SetActive(nextOn);
    }

    public void launch()
    {
        if(instructionsAnim.name == "TTE_simulator_instructions_anim")
        {
            SceneManager.LoadScene("tteMeshRender");
        }
        else if(instructionsAnim.name == "TEE_simulator_instructions_anim")
        {
            SceneManager.LoadScene("teeMeshRender");
        }
    }

    public void home()
    {
        SceneManager.LoadScene("cardiacUltrasoundStartScreen");
    }
}
