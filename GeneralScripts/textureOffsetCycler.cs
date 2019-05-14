using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textureOffsetCycler : MonoBehaviour {

    public float cyclerX = 0.015f;
    public float cyclerY = 0.085f;
    public Material mat;
    Renderer rend;

	void Update ()
    {
        //script modified from official Unity scripting page for mainTextureScale
        float cycleX = Mathf.Sin(Time.time) * cyclerX + 1;
        float cycleY = Mathf.Cos(Time.time) * cyclerY + 1;

        mat.mainTextureScale = new Vector2(cycleX, cycleY);
    }
}
