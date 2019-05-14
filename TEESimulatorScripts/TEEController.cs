using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class TEEController : MonoBehaviour {

    string data;
    string[] outputData;
    SerialPort sp = new SerialPort("COM3", 38400);

    float ardPitch;
    float ardYaw;
    float dist;
    float initHeight;
    float initTwist;
    float initDist;

    public float moveSpeed;

    public static float ardOmni;
    public static float twist;
    public static float deltaDist;
    public static float deltaTwist;
    public static float corrAnteflex;
    public static float corrLateral;

    void Start () {
        sp.Open();
        Thread ardThread = new Thread(new ThreadStart(ReadFromArduino));
        ardThread.IsBackground = true;
        ardThread.Start();
        StartCoroutine(GetHeight());
    }
	
	void Update () {

        outputData = data.Split(',');

        // head rotations
        ardPitch = float.Parse(outputData[1]);
        ardYaw = float.Parse(outputData[0]);

        // omniplane
        ardOmni = int.Parse(outputData[2]);

        // head twist
        twist = float.Parse(outputData[3]);
        deltaTwist = initTwist - twist;

        //distance
        dist = float.Parse(outputData[4]);
        deltaDist = initDist - dist;

        // corrections for the input arduino values to unity
        corrAnteflex = (ardPitch - 255);
        corrLateral = (ardYaw/10) - 35;

        if (corrAnteflex >= 35)
        {
            corrAnteflex = 35;
        }

        if (corrLateral <= -35)
        {
            corrLateral = -35;
        }
    }

    public void ReadFromArduino()
    {
        // reads values from arduino
        while (true)
        {
            data = sp.ReadLine();
        }
    }

    private IEnumerator GetHeight()
    {
        // need a delay to set the initial height of the controller
        yield return new WaitForSeconds(2.0f);
        initDist = float.Parse(outputData[4]);
        initTwist = float.Parse(outputData[3]);
    }
}
