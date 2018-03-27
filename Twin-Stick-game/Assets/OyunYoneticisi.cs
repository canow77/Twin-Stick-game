using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; // <<<<< biz ekledik

public class OyunYoneticisi : MonoBehaviour {

    public bool kaydediyor = true;

	// Update is called once per frame
	void Update () {
		if(CrossPlatformInputManager.GetButton("Kayityap"))     {            kaydediyor = false;        }
        else                                                    {            kaydediyor = true;         }
	}
}
