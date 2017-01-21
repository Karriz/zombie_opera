using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frequency : MonoBehaviour {
    public AudioSource ad;
    public GameObject low, high, mid;
	// Use this for initialization

    void Start ()
    {
        ad.pitch = 1f;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ad.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space)){
            ad.Stop();
            low.SetActive(false);
            high.SetActive(false);
            mid.SetActive(false);
        }
        else if (!ad.isPlaying)
        {
            low.SetActive(false);
            high.SetActive(false);
            mid.SetActive(false);
        }
        var D = Input.GetAxis("Mouse ScrollWheel")*0.2f;
        ad.pitch -= D;

        ad.pitch = Mathf.Clamp(ad.pitch, 0.5f, 2f);

        if (ad.isPlaying)
        {
            if (ad.pitch <= 1)
            {
                low.SetActive(true);
                high.SetActive(false);
                mid.SetActive(false);
            }
            else if (ad.pitch > 1 && ad.pitch <= 1.4f)
            {
                low.SetActive(false);
                high.SetActive(false);
                mid.SetActive(true);
            }
            else if (ad.pitch > 1.4f)
            {
                low.SetActive(false);
                high.SetActive(true);
                mid.SetActive(false);
            }
        }
    }
}
