using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frequency : MonoBehaviour {
    public AudioSource ad;
    public GameObject low, high, mid;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ad.Play();
        }
      if (Input.GetKeyUp(KeyCode.Space)){
            ad.Stop();
        }
        var D = Input.GetAxis("Mouse ScrollWheel")*2;
        ad.pitch -= D;
        if (ad.pitch <= -3) {
            low.SetActive(true);
            high.SetActive(false);
            mid.SetActive(false);
        }
        else if (ad.pitch > -3 && ad.pitch <= 3)
        {
            low.SetActive(false);
            high.SetActive(false);
            mid.SetActive(true);
        }
        else if (ad.pitch > 3)
        {
            low.SetActive(false);
            high.SetActive(true);
            mid.SetActive(false);
        }
    }
}
