using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfiCubugu : MonoBehaviour {

    public float panSpeed = 10f;

    private GameObject oyuncu;
    private Vector3 kolRotasyonu;

	// Use this for initialization
	void Start () {
        oyuncu = GameObject.FindGameObjectWithTag("Player");
        kolRotasyonu = transform.rotation.eulerAngles; // bu objenin bütün açılarını atadı
    }
	
	// Update is called once per frame
	void Update () {
        /*
        kolRotasyonu.y += Input.GetAxis("RHoriz") * panSpeed;
        kolRotasyonu.x += Input.GetAxis("RVert") * panSpeed;
        */
        kolRotasyonu.y += Input.GetAxis("Mouse X") * panSpeed;
        kolRotasyonu.x += Input.GetAxis("Mouse Y") * panSpeed;

        transform.position = oyuncu.transform.position;
        transform.rotation = Quaternion.Euler(kolRotasyonu);
	}
}
