using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour {
	public int score = 0;

    public UnityEngine.UI.Text scoretext;

    void Start()
    {
        scoretext = GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>();
    }

    void Update()
    {
        scoretext.text = score.ToString();
    }
}
