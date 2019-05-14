using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOnLoad : MonoBehaviour {

    public GameObject off;

	void Start () {
        off.SetActive(false);
	}
}
