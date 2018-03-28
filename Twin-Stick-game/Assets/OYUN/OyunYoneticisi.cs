using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; // <<<<< biz ekledik

public class OyunYoneticisi : MonoBehaviour {

    public bool kaydediyor = true;

    private bool isPaused = false;
    private float baslangicFixedDeltaTime;


    void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(1));
        print(PlayerPrefsManager.IsLevelUnlocked(2));
        baslangicFixedDeltaTime = Time.fixedDeltaTime;
        print(baslangicFixedDeltaTime);
    }

    // Update is called once per frame
    void Update () {

		if(CrossPlatformInputManager.GetButton("Kayityap"))     {            kaydediyor = false;        }
        else                                                    {            kaydediyor = true;         }

        if     (Input.GetKeyDown(KeyCode.P) &&  isPaused )        { isPaused = false; ResumeGame();     }
        else if(Input.GetKeyDown(KeyCode.P) && !isPaused )        { isPaused = true ; PauseGame();      }

    }    

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = baslangicFixedDeltaTime;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}
