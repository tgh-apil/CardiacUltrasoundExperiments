using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour {

    public Animator idleHeartAnim;

    public void tteModule()
    {
        idleHeartAnim.SetTrigger("exit");
        StartCoroutine(exitAnim(1));
    }

    public void teeModule()
    {
        idleHeartAnim.SetTrigger("exit");
        StartCoroutine(exitAnim(2));
    }

    public void quit()
    {
        Application.Quit();
    }

    public IEnumerator exitAnim(int moduleNum)
    {
        yield return new WaitForSeconds(1.0f);

        if (moduleNum == 1)
        {
            SceneManager.LoadScene("tteInstructionsScreen");
        }
        if(moduleNum == 2)
        {
            SceneManager.LoadScene("teeInstructionsScreen");
        }
        
    }

}
