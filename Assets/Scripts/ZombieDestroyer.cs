using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDestroyer : MonoBehaviour {
	public ZombieSpawner zombieSpawner;
	public GameScore gameScore;
	public string currentTag = "Low";

	void OnTriggerEnter2D (Collider2D other_ ){
		if (other_.CompareTag (this.currentTag)) {
			zombieSpawner.DeactivateZombie (other_.gameObject);
			// Increase the score
			this.gameScore.score += 1;
		}
	}
}
