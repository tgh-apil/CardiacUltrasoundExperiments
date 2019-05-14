using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class heartManager : MonoBehaviour {

    public GameObject[] heartArray;
    public GameObject[] heartButtons;
    public Animator congenitalMenuAnim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            congenitalSwitch();
        }

        
    }

    void heartsOff()
    {
        for (int i = 0; i < heartArray.Length; i++)
        {
            heartArray[i].SetActive(false);
        }
    }

    public void heartSwitch()
    {
        //this line was working but it is no longer working and I HAVE NO IDEA WHY!
        //string buttonName = EventSystem.current.currentSelectedGameObject.name;
    }

    //just going to hard code these for now until i figure out what the hell is going on...

    public void heart1()
    {
        heartsOff();
        heartArray[0].SetActive(true);
        congenitalMenuAnim.SetBool("isOpening", false);
    }

    public void heart2()
    {
        heartsOff();
        heartArray[1].SetActive(true);
        congenitalMenuAnim.SetBool("isOpening", false);
    }

    public void heart3()
    {
        heartsOff();
        heartArray[2].SetActive(true);
        congenitalMenuAnim.SetBool("isOpening", false);
    }

    public void heart4()
    {
        heartsOff();
        heartArray[3].SetActive(true);
        congenitalMenuAnim.SetBool("isOpening", false);
    }

    public void heart5()
    {
        heartsOff();
        heartArray[4].SetActive(true);
        congenitalMenuAnim.SetBool("isOpening", false);
    }

    public void heart6()
    {
        heartsOff();
        heartArray[5].SetActive(true);
        congenitalMenuAnim.SetBool("isOpening", false);
    }

    void congenitalSwitch()
    {
        if (congenitalMenuAnim.GetBool("isOpening") == false)
        {
            congenitalMenuAnim.SetBool("isOpening", true);
        }
        else
        {
            congenitalMenuAnim.SetBool("isOpening", false);
        }
    }
}
