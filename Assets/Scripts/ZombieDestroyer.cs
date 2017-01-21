using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDestroyer : MonoBehaviour {
	public ZombieSpawner zombieSpawner;
	private GameScore gameScore;
	public string currentTag = "Low";

    void Start()
    {
        gameScore = GameObject.Find("Main Camera").GetComponent<GameScore>();
    }

	void OnTriggerEnter2D (Collider2D other_ ){
		if (other_.CompareTag (this.currentTag)) {
            if (zombieSpawner != null && gameObject != null)
            {
                zombieSpawner.DeactivateZombie(gameObject);
                // Increase the score
                this.gameScore.score += 1;
            }
		}
	}
}
