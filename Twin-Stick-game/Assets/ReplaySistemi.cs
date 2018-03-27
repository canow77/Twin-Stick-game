using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySistemi : MonoBehaviour {

    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private OyunYoneticisi yonetici;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        yonetici  = GameObject.FindObjectOfType<OyunYoneticisi>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (yonetici.kaydediyor)        {            Kayit();        } 
        else                            {            Oynat();        }
    }

    void Oynat()
    {
        rigidBody.isKinematic = true;
        int kare = Time.frameCount % bufferFrames; // örnek   -- 20 % 8 = (8 * 2) + 4 --   bize kalan "4" sayısı 
        print("Oynatılacak kare sayısı " + kare);
        transform.position = keyFrames[kare].pozisyon;
        transform.rotation = keyFrames[kare].rotasyon;
    }

    void Kayit()
    {
        rigidBody.isKinematic = false;
        int kare = Time.frameCount % bufferFrames; // örnek   -- 20 % 8 = (8 * 2) + 4 --   bize kalan "4" sayısı 
        float zaman = Time.time;
        print("Hafızaya alınan kare sayısı " + kare);

        keyFrames[kare] = new MyKeyFrame(zaman, transform.position, transform.rotation);
    }
}

// Structer KURMA---------------------------------------------------------------------
/// <summary>
/// STRUCTURE  "zamanı, rotasyonu ve pozisyonu" kaydettiğimiz yapı
/// </summary>
public struct MyKeyFrame {

    public float frameTime;
    public Vector3 pozisyon;
    public Quaternion rotasyon;

    public MyKeyFrame(float aTime, Vector3 aPozisyon, Quaternion aRotasyon)
    {
        frameTime = aTime;
        pozisyon = aPozisyon;
        rotasyon = aRotasyon;
    }
}
// Structer KURMA---------------------------------------------------------------------
