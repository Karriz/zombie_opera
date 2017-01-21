using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("GameOver").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelRestart()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}
