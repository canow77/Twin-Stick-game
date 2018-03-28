using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraPan : MonoBehaviour {

    private GameObject oyuncu;

	// Use this for initialization
	void Start () {
        oyuncu = GameObject.FindGameObjectWithTag("Player");
	}
	
	void LateUpdate () {
        transform.LookAt(oyuncu.transform);
    }
}
